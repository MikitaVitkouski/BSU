#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "Fraction.h"

QT_BEGIN_NAMESPACE
namespace Ui {
class MainWindow;
}
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
private slots:
    void onAddClicked();
    void onSubClicked();
    void onMulClicked();
    void onDivClicked();
    void onPowClicked();
    void onEvaluateClicked();

private:
    Ui::MainWindow *ui;

    Fraction getFraction1() const;
    Fraction getFraction2() const;
    void setResult(const QString& result);

    Fraction evaluate(const QString& expression);
};
#endif // MAINWINDOW_H
