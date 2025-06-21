#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QDir>
#include <QFile>
#include <QPushButton>
#include <QTimer>
#include <windows.h>
#include <QPaintEvent>
#include <QPainter>
#include "RamLabel.h"

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
    void onbtnEasyModeClicked();
    void onbtnMediumModeClicked();
    void onbtnHardModeClicked();
    void onbtnExpertModeClicked();
    void updateMemoryUsage();

private:
    Ui::MainWindow *ui;
    QTimer *ramTimer;
    int memoryUsagePercent;
    RamLabel* ramLabel;
};
#endif // MAINWINDOW_H
