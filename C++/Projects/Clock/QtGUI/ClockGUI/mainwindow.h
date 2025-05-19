#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "Clock.h"
#include "Stopwatch.h"
#include <QTimer>
#include <QDateTime>
#include <QTimeZone>
#include <QMEssageBox>
#include <QTimeEdit>
#include "TimerManager.h"
#include "AlarmManager.h"
#include <QListWidgetItem>
#include <QFile>

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
    void on_btnResumeStopwatch_clicked();
    void on_btnResetStopwatch_clicked();
    void on_btnAddLap_manualclicked();
    void on_btnStartTimer_clicked();
    void on_btnPauseTimer_clicked();
    void on_btnResumeTimer_clicked();
    void on_btnResetTimer_clicked();
    void updateAlarmList();
    void checkAlarms();
    void on_btnAddAlarm_clicked();
    void on_btnDeleteAlarms_clicked();
    void onAlarmItemDoubleClicked(QListWidgetItem* item);
    void on_btnRemoveSelectedAlarm_clicked();

private:
    Ui::MainWindow *ui;
    Clock clock;
    QTimer* timer;
    void populateTimezones();
    Stopwatch stopwatch;
    QTimer* stopwatchTimer;
    QTimer* countdownTimer;
    int totalSecondsRemaining = 0;
    void onCountdownTick();
    void updateTimeEditDisplay();
    TimerManager timerManager;
    AlarmManager alarmManager;

};
#endif // MAINWINDOW_H
