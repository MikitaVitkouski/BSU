#include "mainwindow.h"
#include "./ui_mainwindow.h"
#include <QTimer>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
    , timer(new QTimer(this))
{
    ui->setupUi(this);

    // Pages
    connect(ui->btnAlarm, &QPushButton::clicked, this, &MainWindow::onAlarmClicked);
    connect(ui->btnStopwatch, &QPushButton::clicked, this, &MainWindow::onStopwatchClicked);
    connect(ui->btnClock, &QPushButton::clicked, this, &MainWindow::onClockClicked);
    connect(ui->btnTimer, &QPushButton::clicked, this, &MainWindow::onTimerClicked);

    // Timezones
    populateTimezones();
    connect(ui->comboBoxTimezone, QOverload<int>::of(&QComboBox::currentIndexChanged),
            this, &MainWindow::onTimezoneChanged);

    // Timer
    connect(timer, &QTimer::timeout, this, &MainWindow::updateClockTime);
    timer->start(999); // updating every second

    updateClockTime(); // update clock time when launched
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::onAlarmClicked()      { ui->stackedWidget->setCurrentIndex(0); }
void MainWindow::onStopwatchClicked()  { ui->stackedWidget->setCurrentIndex(1); }
void MainWindow::onClockClicked()      { ui->stackedWidget->setCurrentIndex(2); }
void MainWindow::onTimerClicked()      { ui->stackedWidget->setCurrentIndex(3); }

void MainWindow::populateTimezones()
{
    ui->comboBoxTimezone->addItem("London (UTC+0)", "Europe/London");
    ui->comboBoxTimezone->addItem("Moscow (UTC+3)", "Europe/Moscow");
    ui->comboBoxTimezone->addItem("Tokyo (UTC+9)", "Asia/Tokyo");
    ui->comboBoxTimezone->addItem("New York (UTC-5)", "America/New_York");

    // Moscow by default
    int index = ui->comboBoxTimezone->findData("Europe/Moscow");
    if (index != -1)
        ui->comboBoxTimezone->setCurrentIndex(index);
}

void MainWindow::onTimezoneChanged(int index)
{
    QString tz = ui->comboBoxTimezone->itemData(index).toString();
    clock.setTimezone(tz.toStdString());
    updateClockTime();
}

void MainWindow::updateClockTime()
{
    ui->labelTime->setText(QString::fromStdString(clock.getTime()));
}
