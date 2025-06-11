#include "ExpressionLineEdit.h"
#include <QKeyEvent>

ExpressionLineEdit::ExpressionLineEdit(QWidget* parent) : QLineEdit(parent) { }

void ExpressionLineEdit::keyPressEvent(QKeyEvent *event) {
    if (event->key() == Qt::Key_Return || event->key() == Qt::Key_Enter) {
        emit enterPressed();
    } else if (event->key() == Qt::Key_Escape) {
        emit escapePressed();
    } else {
        QLineEdit::keyPressEvent(event);
    }
}
