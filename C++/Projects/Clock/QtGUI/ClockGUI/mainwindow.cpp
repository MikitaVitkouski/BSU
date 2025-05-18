#include "mainwindow.h"
#include "./ui_mainwindow.h"
#include <QTimer>
#include <QDateTime>
#include <QTimeZone>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
    , timer(new QTimer(this))
{
    ui->setupUi(this);
    QString styleSheet = R"(
    QWidget {
        background-color: #f5faff;
        color: #2c3e50;
        font-family: "Segoe UI", "Roboto", sans-serif;
        font-size: 16px;
    }

    QLabel {
        font-size: 16px;
        color: #2c3e50;
        text-align: center;
    }

    QLabel#labelTime, QLabel#labelDate {
        color: qlineargradient(
            x1: 0, y1: 0,
            x2: 1, y2: 0,
            stop: 0 #00aaff,
            stop: 1 #66ccff
        );
        font-weight: bold;
        font-size: 45px;
        padding: 10px 20px;
        border-radius: 16px;
        background-color: rgba(0, 170, 255, 0.05);
        border: 1px solid #cceeffl;
    }

    QPushButton {
        background-color: #00aaff;
        color: white;
        border: none;
        border-radius: 8px;
        padding: 8px 16 px;
        font-weight: 500;
    }

    QPushButton:hover {
        background-color: #007acc;
    }

    QComboBox {
        background-color: #ffffff;
        color: #2c3e50;
        border: 1px solid #99dfff;
        padding: 5px 10px;
        border-radius: 6px;
    }

    QComboBox:hover {
        border: 1px solid #00aaff;
    }

    QComboBox:drop-down {
        border: none;
        background-color: #e0f7ff;
    }

    QLineEdit {
        background-color: #ffffff;
        border: 1px solid #99dfff;
        border-radius: 6px;
        padding: 5px;
        color: #2c3e50;
    }
    QLineEdit:focus {
    : 1px solid #00aaff;
    }
    )";

    this->setStyleSheet(styleSheet);
    ui->comboBoxTimezone->setMaxVisibleItems(15);
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

    stopwatchTimer = new QTimer(this);
    connect(stopwatchTimer, &QTimer::timeout, this, &MainWindow::updateStopwatchDisplay);

    connect(ui->btnPlayStopwatch, &QPushButton::clicked, this,&MainWindow::on_btnPlayStopwatch_clicked);
    connect(ui->btnPauseStopwatch, &QPushButton::clicked, this,&MainWindow::on_btnPauseStopwatch_clicked);
    connect(ui->btnResumeStopwatch, &QPushButton::clicked, this,&MainWindow::on_btnResumeStopwatch_clicked);
    connect(ui->btnResetStopwatch, &QPushButton::clicked, this,&MainWindow::on_btnResetStopwatch_clicked);
    connect(ui->btnAddLap, &QPushButton::clicked, this,&MainWindow::on_btnAddLap_clicked);
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
    ui->comboBoxTimezone->addItem("Moscow (UTC+3)", "Europe/Moscow");
    ui->comboBoxTimezone->addItem("London (UTC+1)", "Europe/London");
    ui->comboBoxTimezone->addItem("Tokyo (UTC+9)", "Asia/Tokyo");
    ui->comboBoxTimezone->addItem("New York (UTC-5)", "America/New_York");
    ui->comboBoxTimezone->addItem("Baker Island (UTC−12)", "Etc/GMT+12");
    ui->comboBoxTimezone->addItem("American Samoa (UTC−11)", "Pacific/Pago_Pago");
    ui->comboBoxTimezone->addItem("Honolulu (UTC−10)", "Pacific/Honolulu");
    ui->comboBoxTimezone->addItem("Anchorage (UTC−9)", "America/Anchorage");
    ui->comboBoxTimezone->addItem("Los Angeles (UTC−8)", "America/Los_Angeles");
    ui->comboBoxTimezone->addItem("Denver (UTC−7)", "America/Denver");
    ui->comboBoxTimezone->addItem("Mexico City (UTC−6)", "America/Mexico_City");
    ui->comboBoxTimezone->addItem("Santiago (UTC−4)", "America/Santiago");
    ui->comboBoxTimezone->addItem("Buenos Aires (UTC−3)", "America/Argentina/Buenos_Aires");
    ui->comboBoxTimezone->addItem("South Georgia (UTC−2)", "Atlantic/South_Georgia");
    ui->comboBoxTimezone->addItem("Azores (UTC−1)", "Atlantic/Azores");
    ui->comboBoxTimezone->addItem("Reykjavik (UTC+0)", "Atlantic/Reykjavik");
    ui->comboBoxTimezone->addItem("Paris (UTC+1)", "Europe/Paris");
    ui->comboBoxTimezone->addItem("Berlin (UTC+2)", "Europe/Berlin");
    ui->comboBoxTimezone->addItem("Cairo (UTC+2)", "Africa/Cairo");
    ui->comboBoxTimezone->addItem("Johannesburg (UTC+2)", "Africa/Johannesburg");
    ui->comboBoxTimezone->addItem("Nairobi (UTC+3)", "Africa/Nairobi");
    ui->comboBoxTimezone->addItem("Dubai (UTC+4)", "Asia/Dubai");
    ui->comboBoxTimezone->addItem("Baku (UTC+4)", "Asia/Baku");
    ui->comboBoxTimezone->addItem("Karachi (UTC+5)", "Asia/Karachi");
    ui->comboBoxTimezone->addItem("Tashkent (UTC+5)", "Asia/Tashkent");
    ui->comboBoxTimezone->addItem("Dhaka (UTC+6)", "Asia/Dhaka");
    ui->comboBoxTimezone->addItem("Almaty (UTC+6)", "Asia/Almaty");
    ui->comboBoxTimezone->addItem("Bangkok (UTC+7)", "Asia/Bangkok");
    ui->comboBoxTimezone->addItem("Jakarta (UTC+7)", "Asia/Jakarta");
    ui->comboBoxTimezone->addItem("Beijing (UTC+8)", "Asia/Shanghai");
    ui->comboBoxTimezone->addItem("Singapore (UTC+8)", "Asia/Singapore");
    ui->comboBoxTimezone->addItem("Tokyo (UTC+9)", "Asia/Tokyo");
    ui->comboBoxTimezone->addItem("Seoul (UTC+9)", "Asia/Seoul");
    ui->comboBoxTimezone->addItem("Sydney (UTC+10)", "Australia/Sydney");
    ui->comboBoxTimezone->addItem("Vladivostok (UTC+10)", "Asia/Vladivostok");
    ui->comboBoxTimezone->addItem("Magadan (UTC+11)", "Asia/Magadan");
    ui->comboBoxTimezone->addItem("Noumea (UTC+11)", "Pacific/Noumea");
    ui->comboBoxTimezone->addItem("Auckland (UTC+12)", "Pacific/Auckland");
    ui->comboBoxTimezone->addItem("Fiji (UTC+12)", "Pacific/Fiji");
    ui->comboBoxTimezone->addItem("Chatham Islands (UTC+12:45)", "Pacific/Chatham");
    ui->comboBoxTimezone->addItem("Apia (UTC+13)", "Pacific/Apia");
    ui->comboBoxTimezone->addItem("Nukuʻalofa (UTC+13)", "Pacific/Tongatapu");
    ui->comboBoxTimezone->addItem("Kiritimati (UTC+14)", "Pacific/Kiritimati");
    ui->comboBoxTimezone->addItem("Rome (UTC+1)", "Europe/Rome");
    ui->comboBoxTimezone->addItem("Helsinki (UTC+2)", "Europe/Helsinki");
    ui->comboBoxTimezone->addItem("Tehran (UTC+3:30)", "Asia/Tehran");
    ui->comboBoxTimezone->addItem("Mumbai (UTC+5:30)", "Asia/Kolkata");
    ui->comboBoxTimezone->addItem("Yangon (UTC+6:30)", "Asia/Yangon");
    ui->comboBoxTimezone->addItem("Adelaide (UTC+9:30)", "Australia/Adelaide");

    // Moscow (UTC+3) by default
    int index = ui->comboBoxTimezone->findData("Europe/Moscow");
    if (index != -1) {
        ui->comboBoxTimezone->setCurrentIndex(index);
        onTimezoneChanged(index);
    }
}

void MainWindow::onTimezoneChanged(int index)
{
    QString tz = ui->comboBoxTimezone->itemData(index).toString();
    clock.setTimezone(tz.toStdString());
    updateClockTime();
}

void MainWindow::updateClockTime()
{
    QString timezoneId = ui->comboBoxTimezone->currentData().toString();
    QTimeZone tz(timezoneId.toUtf8());
    QDateTime nowUtc = QDateTime::currentDateTimeUtc();
    QDateTime localTime = nowUtc.toTimeZone(tz);

    ui->labelTime->setText(QString::fromStdString(clock.getTime()));
    ui->labelDate->setText(localTime.date().toString("dd.MM.yyyy"));
}

void MainWindow::on_btnPlayStopwatch_clicked() {
    stopwatch.reset();
    ui->listWidgetLaps->clear();
    stopwatch.start();
    stopwatchTimer->start(10); // updating timer each 100 ms
}

void MainWindow::on_btnPauseStopwatch_clicked() {
    if (stopwatch.isRunning()) {
        stopwatch.pause();
        stopwatchTimer->stop();
    }
}

void MainWindow::on_btnResumeStopwatch_clicked() {
    if (!stopwatch.isRunning()) {
        stopwatch.resume();
        stopwatchTimer->start(10);
    }
}

void MainWindow::on_btnResetStopwatch_clicked() {
    stopwatch.reset();
    stopwatchTimer->stop();
    ui->labelTimeStopwatch->setText("00:00:00.000");
    ui->listWidgetLaps->clear();
    ui->btnPauseStopwatch->setText("Pause");
}

void MainWindow::on_btnAddLap_clicked() {
    if (!stopwatch.isRunning()) return;

    stopwatch.lap();
    const auto& laps = stopwatch.getLaps();

    const auto& lastLap = laps.back();
    int totalMs = lastLap.count();
    int h = totalMs / 3600000;
    int m = (totalMs / 60000) % 60;
    int s = (totalMs / 1000) % 60;
    int ms = totalMs % 1000;

    QString lapStr = QString("Lap %1 - %2:%3:%4.%5")
                         .arg(laps.size())
                         .arg(h, 2, 10, QChar('0'))
                         .arg(m, 2, 10, QChar('0'))
                         .arg(s, 2, 10, QChar('0'))
                         .arg(ms, 3, 10, QChar('0'));

    ui->listWidgetLaps->addItem(lapStr);
}

void MainWindow::updateStopwatchDisplay() {
    auto ms = stopwatch.elapsed();
    int total = ms.count();

    int h = total / 3600000;
    int m = (total / 60000) % 60;
    int s = (total / 1000) % 60;
    int milli = total % 1000;

    QString timeStr = QString("%1:%2:%3.%4")
                          .arg(h, 2, 10, QChar('0'))
                          .arg(m, 2, 10, QChar('0'))
                          .arg(s, 2, 10, QChar('0'))
                          .arg(milli, 3, 10, QChar('0'));

    ui->labelTimeStopwatch->setText(timeStr);
}
