#include "mainwindow.h"
#include "./ui_mainwindow.h"

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

    QTimeEdit {
        font-size: 32px;
        font-weight: bold;
        border: 2px solid #2c3e50;
        border-radius: 12px;
        padding: 8px 16px;
        background-color: #f0faff;
        color: #2c3e50;
    }

    QListWidget::item {
        background-color: #eaf6ff;
        padding: 8px 12px;
        margin: 4px;
        border-radius: 6px;
        color: #2c3e50;
    }

    QListWidget::item:selected {
        background-color: #cceeff;
        color: #004466;
    }

    QListWidget {
        border: 1px solid #cceeff;
        border-radius: 12px;
        background-color: rgba(0, 170, 255, 0.04);
        padding: 10px;
        margin-top: 10px;
        color: #2c3e50;
        font-size: 16px;
    }

    QScrollBar:vertical {
        border: none;
        background: transparent;
        width: 12px;
        margin: 4px 0 4px 0;
        border-radius: 6px;
    }

    QScrollBar::handle:vertical {
        background: #00aaff;
        min-height: 20px;
        border-radius: 6px;
    }

    QScrollBar::handle:vertical:hover {
        background: #007acc;
    }

    QScrollBar::sub-line:vertical,
    QScrollBar::add-line:vertical {
        height: 0;
        subcontrol-origin: margin;
    }

    QScrollBar::add-page:vertical,
    QScrollBar::sub-page:vertical {
        background: none;
    }

    QLabel#labelTime, QLabel#labelDate, QLabel#labelTimezone, QLabel#labelTimeStopwatch {
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

    // Clock
    connect(timer, &QTimer::timeout, this, &MainWindow::updateClockTime);
    timer->start(999); // updating every second

    updateClockTime(); // update clock time when launched

    stopwatchTimer = new QTimer(this);
    connect(stopwatchTimer, &QTimer::timeout, this, &MainWindow::updateStopwatchDisplay);

    connect(ui->btnPlayStopwatch, &QPushButton::clicked, this,&MainWindow::on_btnPlayStopwatch_clicked);
    connect(ui->btnPauseStopwatch, &QPushButton::clicked, this,&MainWindow::on_btnPauseStopwatch_clicked);
    connect(ui->btnResumeStopwatch, &QPushButton::clicked, this,&MainWindow::on_btnResumeStopwatch_clicked);
    connect(ui->btnResetStopwatch, &QPushButton::clicked, this,&MainWindow::on_btnResetStopwatch_clicked);
    connect(ui->btnAddLap, &QPushButton::clicked, this,&MainWindow::on_btnAddLap_manualclicked);

    // Timer
    connect(ui->btnStartTimer, &QPushButton::clicked, this, &MainWindow::on_btnStartTimer_clicked);

    countdownTimer = new QTimer(this);
    ui->timeEditTimer->setDisplayFormat("HH:mm:ss");
    ui->timeEditTimer->setTime(QTime(0, 0, 0));
    ui->timeEditTimer->setButtonSymbols(QAbstractSpinBox::NoButtons);
    ui->timeEditTimer->setAlignment(Qt::AlignCenter);

    connect(countdownTimer, &QTimer::timeout, this, &MainWindow::onCountdownTick);
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
    ui->comboBoxTimezone->addItem("Moscow", "Europe/Moscow");
    ui->comboBoxTimezone->addItem("London", "Europe/London");
    ui->comboBoxTimezone->addItem("Tokyo", "Asia/Tokyo");
    ui->comboBoxTimezone->addItem("New York", "America/New_York");
    ui->comboBoxTimezone->addItem("Baker Island", "Etc/GMT+12");
    ui->comboBoxTimezone->addItem("American Samoa", "Pacific/Pago_Pago");
    ui->comboBoxTimezone->addItem("Honolulu", "Pacific/Honolulu");
    ui->comboBoxTimezone->addItem("Anchorage", "America/Anchorage");
    ui->comboBoxTimezone->addItem("Los Angeles", "America/Los_Angeles");
    ui->comboBoxTimezone->addItem("Denver", "America/Denver");
    ui->comboBoxTimezone->addItem("Mexico City", "America/Mexico_City");
    ui->comboBoxTimezone->addItem("Santiago", "America/Santiago");
    ui->comboBoxTimezone->addItem("Buenos Aires", "America/Argentina/Buenos_Aires");
    ui->comboBoxTimezone->addItem("South Georgia", "Atlantic/South_Georgia");
    ui->comboBoxTimezone->addItem("Azores", "Atlantic/Azores");
    ui->comboBoxTimezone->addItem("Reykjavik", "Atlantic/Reykjavik");
    ui->comboBoxTimezone->addItem("Paris", "Europe/Paris");
    ui->comboBoxTimezone->addItem("Berlin", "Europe/Berlin");
    ui->comboBoxTimezone->addItem("Cairo", "Africa/Cairo");
    ui->comboBoxTimezone->addItem("Johannesburg", "Africa/Johannesburg");
    ui->comboBoxTimezone->addItem("Nairobi", "Africa/Nairobi");
    ui->comboBoxTimezone->addItem("Dubai", "Asia/Dubai");
    ui->comboBoxTimezone->addItem("Baku", "Asia/Baku");
    ui->comboBoxTimezone->addItem("Karachi", "Asia/Karachi");
    ui->comboBoxTimezone->addItem("Tashkent", "Asia/Tashkent");
    ui->comboBoxTimezone->addItem("Dhaka", "Asia/Dhaka");
    ui->comboBoxTimezone->addItem("Almaty", "Asia/Almaty");
    ui->comboBoxTimezone->addItem("Bangkok", "Asia/Bangkok");
    ui->comboBoxTimezone->addItem("Jakarta", "Asia/Jakarta");
    ui->comboBoxTimezone->addItem("Beijing", "Asia/Shanghai");
    ui->comboBoxTimezone->addItem("Singapore", "Asia/Singapore");
    ui->comboBoxTimezone->addItem("Tokyo", "Asia/Tokyo");
    ui->comboBoxTimezone->addItem("Seoul", "Asia/Seoul");
    ui->comboBoxTimezone->addItem("Sydney", "Australia/Sydney");
    ui->comboBoxTimezone->addItem("Vladivostok", "Asia/Vladivostok");
    ui->comboBoxTimezone->addItem("Magadan", "Asia/Magadan");
    ui->comboBoxTimezone->addItem("Noumea", "Pacific/Noumea");
    ui->comboBoxTimezone->addItem("Auckland", "Pacific/Auckland");
    ui->comboBoxTimezone->addItem("Fiji", "Pacific/Fiji");
    ui->comboBoxTimezone->addItem("Chatham Islands", "Pacific/Chatham");
    ui->comboBoxTimezone->addItem("Apia", "Pacific/Apia");
    ui->comboBoxTimezone->addItem("Nukuʻalofa", "Pacific/Tongatapu");
    ui->comboBoxTimezone->addItem("Kiritimati", "Pacific/Kiritimati");
    ui->comboBoxTimezone->addItem("Rome", "Europe/Rome");
    ui->comboBoxTimezone->addItem("Helsinki", "Europe/Helsinki");
    ui->comboBoxTimezone->addItem("Tehran", "Asia/Tehran");
    ui->comboBoxTimezone->addItem("Mumbai", "Asia/Kolkata");
    ui->comboBoxTimezone->addItem("Yangon", "Asia/Yangon");
    ui->comboBoxTimezone->addItem("Adelaide", "Australia/Adelaide");

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

    int offsetSeconds = tz.offsetFromUtc(nowUtc);
    int hours = offsetSeconds / 3600;
    int minutes = (abs(offsetSeconds) % 3600) / 60;
    QString sign = hours >= 0 ? "+" : "-";

    ui->labelTimezone->setText(QString("%1%2:%3").arg(sign).arg(abs(hours), 2, 10, QChar('0')).arg(minutes, 2, 10, QChar('0')));
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

void MainWindow::on_btnAddLap_manualclicked() {
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

void MainWindow::on_btnStartTimer_clicked() {
    QTime selectedTime = ui->timeEditTimer->time();
    totalSecondsRemaining = QTime(0, 0).secsTo(selectedTime);

    if (totalSecondsRemaining <= 0)
        return;

    ui->btnStartTimer->setEnabled(false);
    ui->timeEditTimer->setEnabled(false);
    countdownTimer->start(1000);
}

void MainWindow::onCountdownTick() {
    if (totalSecondsRemaining <= 0) {
        countdownTimer->stop();
        ui->btnStartTimer->setEnabled(true);
        ui->timeEditTimer->setEnabled(true);
        QMessageBox::information(this, "Timer", "Time's up!");
        return;
    }

    totalSecondsRemaining--;
    updateTimeEditDisplay();
}

void MainWindow::updateTimeEditDisplay() {
    int h = totalSecondsRemaining / 3600;
    int m = (totalSecondsRemaining % 3600) / 60;
    int s = totalSecondsRemaining % 60;

    ui->timeEditTimer->setTime(QTime(h, m, s));
}
