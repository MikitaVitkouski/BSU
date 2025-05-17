#include "mainwindow.h"
#include "./ui_mainwindow.h"
#include <QTimer>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    connect(ui->btnAlarm, &QPushButton::clicked, this, &MainWindow::onAlarmClicked);
    connect(ui->btnStopwatch, &QPushButton::clicked, this, &MainWindow::onStopwatchClicked);
    connect(ui->btnClock, &QPushButton::clicked, this, &MainWindow::onClockClicked);
    connect(ui->btnTimer, &QPushButton::clicked, this, &MainWindow::onTimerClicked);
    ui->stackedWidget->setCurrentIndex(0);
    QTimer *timer = new QTimer(this);
    connect(timer, &QTimer::timeout, this, [this]() {
        ui->labelTime->setText(QString::fromStdString(clock.getTime()));
    });
    timer->start(1000);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::onAlarmClicked() {
    ui->stackedWidget->setCurrentIndex(0);
}

void MainWindow::onStopwatchClicked() {
    ui->stackedWidget->setCurrentIndex(1);
}

void MainWindow::onClockClicked() {
    ui->stackedWidget->setCurrentIndex(2);
}

void MainWindow::onTimerClicked() {
    ui->stackedWidget->setCurrentIndex(3);
}
