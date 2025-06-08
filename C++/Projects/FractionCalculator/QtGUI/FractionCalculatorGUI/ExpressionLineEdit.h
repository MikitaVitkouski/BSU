#ifndef EXPRESSIONLINEEDIT_H
#define EXPRESSIONLINEEDIT_H

#include <QLineEdit>

class ExpressionLineEdit : public QLineEdit {
    Q_OBJECT

public:
    explicit ExpressionLineEdit(QWidget* parent = nullptr);

signals:
    void enterPressed();

protected:
    void keyPressEvent(QKeyEvent *event) override;
};

#endif // EXPRESSIONLINEEDIT_H
