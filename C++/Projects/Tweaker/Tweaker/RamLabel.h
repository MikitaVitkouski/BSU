#ifndef RAMLABEL_H
#define RAMLABEL_H

#include <QLabel>
#include <QPainter>
#include <QPaintEvent>

class RamLabel : public QLabel {
    Q_OBJECT

public:
    explicit RamLabel(QWidget* parent = nullptr);
    int usage = 0;

protected:
    void paintEvent(QPaintEvent* event) override;
};

#endif // RAMLABEL_H
