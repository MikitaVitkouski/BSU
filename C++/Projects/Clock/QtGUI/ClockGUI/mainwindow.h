#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "Clock.h"
#include "Stopwatch.h"

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
    void onTimezoneChanged(int index); // slot to change timezone
    void updateClockTime(); // updating time
    void updateStopwatchDisplay();
    void on_btnPlayStopwatch_clicked();
    void on_btnPauseStopwatch_clicked();
    void on_btnResetStopwatch_clicked();
    void on_btnAddLap_clicked();

private:
    Ui::MainWindow *ui;
    Clock clock;
    QTimer* timer;
    void populateTimezones();
    Stopwatch stopwatch;
    QTimer* stopwatchTimer;
};
#endif // MAINWINDOW_H
