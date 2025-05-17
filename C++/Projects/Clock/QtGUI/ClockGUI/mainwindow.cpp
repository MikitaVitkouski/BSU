#include "mainwindow.h"
#include "./ui_mainwindow.h"
#include <QTimer>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
    , timer(new QTimer(this))
{
    ui->setupUi(this);
QString styleSheet = R"(
    QWidget {
        background-color: #fdfdfd;
        color: #444444;
        font-family: Segoe UI, sans-serif;
        font-size: 16px;
    }

    QLineEdit {
        background-color: #2a2a2a;
        color: #000000;
        border: 2px solid #ffaa00;
        border-radius: 10px;
        padding: 6px;
    }

    QLabel {
        color: #ff6600;
        font-weight: bold;
        font-size: 50px;
    }

    QPushButton {
        background-color: #ffffff;
        color: #333333;
        border: 1 px solid #e0e0e0;
        border-radius: 40px;
        padding: 10px;
        min-width: 60px;
    }

    QPushButton:hover {
        background-color: #f5f5f5;
    }

    QPushButton:pressed {
        background-color: #ff9900;
    }
)";
    this->setStyleSheet(styleSheet);
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
