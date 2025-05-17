#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "Clock.h"

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
    void onAlarmClicked();
    void onStopwatchClicked();
    void onClockClicked();
    void onTimerClicked();

private:
    Ui::MainWindow *ui;
    Clock clock;
};
#endif // MAINWINDOW_H
