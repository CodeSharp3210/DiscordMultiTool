import sys
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
        self.setAttribute(Qt.WA_TranslucentBackground)  # <-- trasparenza

        # Carico l'immagine
        pixmap = QPixmap("GUI.png")
        if pixmap.isNull():
            print("❌ Immagine non trovata!")
        else:
            self.setPixmap(pixmap)
            self.resize(pixmap.width(), pixmap.height())

        # Posiziono in alto a sinistra
        self.move(0, 0)

        self.show()

app = QApplication(sys.argv)
overlay = OverlayImage()
sys.exit(app.exec_())
