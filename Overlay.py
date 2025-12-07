import sys
import os
from PyQt5.QtWidgets import QApplication, QLabel
from PyQt5.QtGui import QPixmap
from PyQt5.QtCore import Qt

class OverlayImage(QLabel):
    def __init__(self):
        super().__init__()

        # Finestra senza bordi, sempre in primo piano, trasparente
        self.setWindowFlags(
            Qt.WindowStaysOnTopHint |
            Qt.FramelessWindowHint |
            Qt.Tool
        )
        self.setAttribute(Qt.WA_TranslucentBackground)  # trasparenza

        script_dir = os.path.dirname(os.path.realpath(__file__))
        image_path = os.path.join(script_dir, "GUI.png")

        # Carico l'immagine
        pixmap = QPixmap(image_path)
        if pixmap.isNull():
            print("Immagine non trovata!")
        else:
            # Ridimensiono l'immagine a metà della larghezza e altezza, mantenendo le proporzioni
            scaled_pixmap = pixmap.scaled(
                pixmap.width() // 2,      # metà larghezza
                pixmap.height() // 2,     # metà altezza
                Qt.KeepAspectRatio,       # mantiene proporzioni
                Qt.SmoothTransformation   # rende l'immagine più liscia
            )
            self.setPixmap(scaled_pixmap)
            self.resize(scaled_pixmap.width(), scaled_pixmap.height())

        # Posiziono in alto a sinistra
        self.move(0, 0)

        self.show()

app = QApplication(sys.argv)
overlay = OverlayImage()
sys.exit(app.exec_())
