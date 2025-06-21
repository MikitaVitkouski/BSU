#include "RamLabel.h"

RamLabel::RamLabel(QWidget* parent)
    : QLabel(parent) { }

void RamLabel::paintEvent(QPaintEvent* event) {
    QLabel::paintEvent(event);

    QPainter p(this);
    if (!p.isActive()) return;

    p.setRenderHint(QPainter::Antialiasing);

    QRectF outerRect = this->rect().adjusted(10, 10, -10, -10);
    qreal thickness = 20.0;

    QRectF innerRect = outerRect.adjusted(thickness/2, thickness/2, -thickness/2, -thickness/2);

    int startAngle = 180 * 16;
    int spanAngle = -static_cast<int>(180 * usage / 100.0 * 16);

    p.setPen(QPen(QColor(204, 238, 255), thickness, Qt::SolidLine, Qt::RoundCap));
    p.drawArc(innerRect, startAngle, -180 * 16);

    p.setPen(QPen(QColor(0, 170, 255), thickness, Qt::SolidLine, Qt::RoundCap));
    p.drawArc(innerRect, startAngle, spanAngle);

    p.setPen(QColor(0, 170, 255));
    p.setFont(QFont("Segoe UI", 24, QFont::Bold));
    p.drawText(this->rect(), Qt::AlignCenter, QString::number(usage) + "%");
}
