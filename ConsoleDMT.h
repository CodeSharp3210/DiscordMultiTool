// discord_tool.c
// Windows-only example: real Discord Rich Presence (requires discord-rpc SDK) + Python launcher
// Compile with: cl discord_tool.c discord-rpc.lib /link /out:discord_tool.exe
// (oppure con Visual Studio project; assicurati di avere discord-rpc include path e link alla .lib)

#define _CRT_SECURE_NO_WARNINGS
#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <process.h> // _beginthreadex
#include <stdbool.h>

// Include the discord-rpc header (devi avere questo file nella include path)
#include "discord_rpc.h"

// --- Globals for RPC ---
static volatile bool rpc_running = false;
static HANDLE rpc_thread_handle = NULL;
static unsigned int rpc_thread_id = 0;
static DiscordRichPresence current_presence;

// Thread that runs Discord_RunCallbacks periodically
unsigned __stdcall rpc_thread_func(void *param) {
    (void)param;
    while (rpc_running) {
        Discord_RunCallbacks();
        Sleep(1000); // call callbacks every 1 second
    }
    _endthreadex(0);
    return 0;
}

// Initialize Discord RPC with a given application ID
bool rpc_init(const char *application_id) {
    if (!application_id || strlen(application_id) == 0) return false;

    DiscordEventHandlers handlers;
    memset(&handlers, 0, sizeof(handlers));
    handlers.ready = NULL;
    handlers.disconnected = NULL;
    handlers.errored = NULL;
    handlers.joinGame = NULL;
    handlers.spectateGame = NULL;
    handlers.joinRequest = NULL;

    // Initialize: the last parameter is the optional Steam ID (NULL here)
    Discord_Initialize(application_id, &handlers, 1, NULL);

    // start callbacks thread
    rpc_running = true;
    rpc_thread_handle = (HANDLE)_beginthreadex(NULL, 0, rpc_thread_func, NULL, 0, &rpc_thread_id);
    return rpc_thread_handle != NULL;
}

// Update presence (fills the DiscordRichPresence struct and calls Discord_UpdatePresence)
void rpc_update(const char *state, const char *details, const char *largeImageKey, const char *largeImageText) {
    memset(&current_presence, 0, sizeof(current_presence));
    if (state && state[0]) current_presence.state = state;
    if (details && details[0]) current_presence.details = details;
    if (largeImageKey && largeImageKey[0]) current_presence.largeImageKey = largeImageKey;
    if (largeImageText && largeImageText[0]) current_presence.largeImageText = largeImageText;
    current_presence.startTimestamp = (long)time(NULL);
    Discord_UpdatePresence(&current_presence);
}

// Shutdown RPC cleanly
void rpc_shutdown() {
    if (rpc_running) {
        rpc_running = false;
        if (rpc_thread_handle) {
            WaitForSingleObject(rpc_thread_handle, INFINITE);
            CloseHandle(rpc_thread_handle);
            rpc_thread_handle = NULL;
        }
        Discord_Shutdown();
    }
}

// --- Python launcher (Start python script and show PID) ---
bool start_python_bot(const char *script_path, DWORD *out_pid) {
    if (!script_path || strlen(script_path) == 0) return false;

    // Check file exists
    DWORD attrib = GetFileAttributesA(script_path);
    if (attrib == INVALID_FILE_ATTRIBUTES) {
        printf("File non trovato: %s\n", script_path);
        return false;
    }

    // Build command line: python "script_path"
    char cmdline[1024];
    snprintf(cmdline, sizeof(cmdline), "python \"%s\"", script_path);

    STARTUPINFOA si;
    PROCESS_INFORMATION pi;
    ZeroMemory(&si, sizeof(si));
    si.cb = sizeof(si);
    ZeroMemory(&pi, sizeof(pi));

    BOOL ok = CreateProcessA(
        NULL,
        cmdline,
        NULL, NULL,
        FALSE,
        CREATE_NO_WINDOW,
        NULL,
        NULL,
        &si,
        &pi
    );

    if (!ok) {
        DWORD err = GetLastError();
        printf("Errore avvio python: codice %lu\n", err);
        return false;
    }

    // We have a running process: return PID and close handles (keep process running)
    if (out_pid) *out_pid = pi.dwProcessId;
    CloseHandle(pi.hThread);
    CloseHandle(pi.hProcess);
    return true;
}

// --- Simple console UI ---
void clear_stdin_remaining() {
    int c;
    while ((c = getchar()) != '\n' && c != EOF) { }
}

int main(void) {
    char input[512];
    char appId[128] = {0};
    printf("DiscordMultiTool Console (RPC reale + Python launcher)\n");
    while (1) {
        printf("\nMenu:\n");
        printf("1) Inizializza Discord RPC (fornisci Application ID)\n");
        printf("2) Aggiorna Rich Presence (state/details/largeImageKey/largeImageText)\n");
        printf("3) Arresta RPC\n");
        printf("4) Avvia bot Python (fornisci percorso .py)\n");
        printf("5) Esci\n");
        printf("Scegli: ");
        if (!fgets(input, sizeof(input), stdin)) break;
        int choice = atoi(input);

        if (choice == 1) {
            printf("Inserisci Application ID: ");
            if (!fgets(appId, sizeof(appId), stdin)) continue;
            appId[strcspn(appId, "\r\n")] = 0;
            if (rpc_init(appId)) {
                printf("RPC inizializzato con App ID: %s\n", appId);
            } else {
                printf("Impossibile inizializzare RPC.\n");
            }
        } else if (choice == 2) {
            if (!rpc_running) {
                printf("RPC non è in esecuzione. Prima inizializzalo (opzione 1).\n");
                continue;
            }
            char state[256] = {0}, details[256] = {0}, imgKey[128] = {0}, imgText[128] = {0};
            printf("State: ");
            if (!fgets(state, sizeof(state), stdin)) continue;
            state[strcspn(state, "\r\n")] = 0;
            printf("Details: ");
            if (!fgets(details, sizeof(details), stdin)) continue;
            details[strcspn(details, "\r\n")] = 0;
            printf("Large Image Key (asset name): ");
            if (!fgets(imgKey, sizeof(imgKey), stdin)) continue;
            imgKey[strcspn(imgKey, "\r\n")] = 0;
            printf("Large Image Text: ");
            if (!fgets(imgText, sizeof(imgText), stdin)) continue;
            imgText[strcspn(imgText, "\r\n")] = 0;

            rpc_update(state, details, imgKey, imgText);
            printf("Presence aggiornato.\n");
        } else if (choice == 3) {
            rpc_shutdown();
            printf("RPC arrestato.\n");
        } else if (choice == 4) {
            char path[512];
            printf("Percorso script Python (.py): ");
            if (!fgets(path, sizeof(path), stdin)) continue;
            path[strcspn(path, "\r\n")] = 0;
            DWORD pid = 0;
            if (start_python_bot(path, &pid)) {
                printf("Bot avviato (PID: %lu)\n", (unsigned long)pid);
            } else {
                printf("Impossibile avviare il bot.\n");
            }
        } else if (choice == 5) {
            printf("Uscita...\n");
            break;
        } else {
            printf("Scelta non valida.\n");
        }
    }

    // Cleanup
    rpc_shutdown();
    return 0;
}
