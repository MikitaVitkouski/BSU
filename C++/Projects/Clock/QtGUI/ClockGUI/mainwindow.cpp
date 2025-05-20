#include "mainwindow.h"
#include "./ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
    , timer(new QTimer(this))
{
    ui->setupUi(this);
    QFile file("E:/Repositories/BSU/C++/Projects/Clock/QtGUI/ClockGUI/style.css");
    if (file.open(QFile::ReadOnly | QFile::Text)) {
        QTextStream stream(&file);
        QString styleSheet = stream.readAll();
        this->setStyleSheet(styleSheet);
        file.close();
    }
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

    ui->btnPlayStopwatch->setEnabled(true);
    ui->btnPauseStopwatch->setEnabled(false);
    ui->btnResetStopwatch->setEnabled(false);
    ui->btnAddLap->setEnabled(false);
    ui->btnResumeStopwatch->setEnabled(false);

    // Timer
    connect(ui->btnStartTimer, &QPushButton::clicked, this, &MainWindow::on_btnStartTimer_clicked);
    connect(ui->btnPauseTimer, &QPushButton::clicked, this, &MainWindow::on_btnPauseTimer_clicked);
    connect(ui->btnResumeTimer, &QPushButton::clicked, this, &MainWindow::on_btnResumeTimer_clicked);
    connect(ui->btnResetTimer, &QPushButton::clicked, this, &MainWindow::on_btnResetTimer_clicked);

    countdownTimer = new QTimer(this);
    ui->timeEditTimer->setDisplayFormat("HH:mm:ss");
    ui->timeEditTimer->setTime(QTime(0, 0, 0));
    ui->timeEditTimer->setButtonSymbols(QAbstractSpinBox::NoButtons);
    ui->timeEditTimer->setAlignment(Qt::AlignCenter);
    ui->btnPauseTimer->setEnabled(false);
    ui->btnResumeTimer->setEnabled(false);
    ui->btnResetTimer->setEnabled(false);

    connect(countdownTimer, &QTimer::timeout, this, &MainWindow::onCountdownTick);

    // Alarm
    // connect(ui->btnAddAlarm, &QPushButton::clicked, this, &MainWindow::on_btnAddAlarm_clicked);

    timer = new QTimer(this);
    connect(timer, &QTimer::timeout, this, &MainWindow::checkAlarms);
    connect(ui->btnDeleteAlarms, &QPushButton::clicked, this, &MainWindow::on_btnDeleteAlarms_clicked);
    connect(ui->listWidgetAlarms, &QListWidget::itemDoubleClicked,this, &MainWindow::onAlarmItemDoubleClicked);
    connect(ui->btnRemoveSelectedAlarm, &QPushButton::clicked, this, &MainWindow::on_btnRemoveSelectedAlarm_clicked);
    timer->start(1000);

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

    ui->btnPlayStopwatch->setEnabled(false);
    ui->btnPauseStopwatch->setEnabled(true);
    ui->btnResetStopwatch->setEnabled(true);
    ui->btnAddLap->setEnabled(true);
    ui->btnResumeStopwatch->setEnabled(true);
}

void MainWindow::on_btnPauseStopwatch_clicked() {
    if (stopwatch.isRunning()) {
        stopwatch.pause();
        stopwatchTimer->stop();
    }
    ui->btnPlayStopwatch->setEnabled(false);
    ui->btnPauseStopwatch->setEnabled(false);
    ui->btnResetStopwatch->setEnabled(true);
    ui->btnAddLap->setEnabled(true);
    ui->btnResumeStopwatch->setEnabled(true);
}

void MainWindow::on_btnResumeStopwatch_clicked() {
    if (!stopwatch.isRunning()) {
        stopwatch.resume();
        stopwatchTimer->start(10);
    }
    ui->btnPlayStopwatch->setEnabled(false);
    ui->btnPauseStopwatch->setEnabled(true);
    ui->btnResetStopwatch->setEnabled(true);
    ui->btnAddLap->setEnabled(true);
    ui->btnResumeStopwatch->setEnabled(false);
}

void MainWindow::on_btnResetStopwatch_clicked() {
    stopwatch.reset();
    stopwatchTimer->stop();
    ui->labelTimeStopwatch->setText("00:00:00.000");
    ui->listWidgetLaps->clear();
    ui->btnPauseStopwatch->setText("Pause");
    ui->btnPlayStopwatch->setEnabled(true);
    ui->btnPauseStopwatch->setEnabled(false);
    ui->btnResetStopwatch->setEnabled(false);
    ui->btnAddLap->setEnabled(false);
    ui->btnResumeStopwatch->setEnabled(false);
}

void MainWindow::on_btnAddLap_manualclicked() {
    if (!stopwatch.isRunning() && ui->btnPauseStopwatch->isEnabled()) return;

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

    ui->btnPlayStopwatch->setEnabled(false);
    ui->btnPauseStopwatch->setEnabled(true);
    ui->btnResetStopwatch->setEnabled(true);
    ui->btnResumeStopwatch->setEnabled(true);
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
    int totalSeconds = QTime(0, 0).secsTo(selectedTime);

    if (totalSeconds <= 0)
        return;

    timerManager.start(std::chrono::seconds(totalSeconds));
    countdownTimer->start(1);

    ui->btnStartTimer->setEnabled(false);
    ui->btnPauseTimer->setEnabled(true);
    ui->btnResetTimer->setEnabled(true);
    ui->timeEditTimer->setEnabled(false);
}

void MainWindow::onCountdownTick() {
    if (timerManager.isFinished()) {
        countdownTimer->stop();
        ui->btnStartTimer->setEnabled(true);
        ui->btnPauseTimer->setEnabled(false);
        ui->btnResumeTimer->setEnabled(false);
        ui->btnResetTimer->setEnabled(true);
        ui->timeEditTimer->setEnabled(true);
        ui->timeEditTimer->setTime(QTime(0, 0, 0));
        return;
    }

    auto remaining = timerManager.remaining();
    int totalMillis = static_cast<int>(remaining.count());
    totalSecondsRemaining = totalMillis / 1000;

    updateTimeEditDisplay();
}

void MainWindow::updateTimeEditDisplay() {
    int h = totalSecondsRemaining / 3600;
    int m = (totalSecondsRemaining % 3600) / 60;
    int s = totalSecondsRemaining % 60;

    ui->timeEditTimer->setTime(QTime(h, m, s));
}

void MainWindow::on_btnPauseTimer_clicked() {
    timerManager.pause();
    countdownTimer->stop();
    ui->btnPauseTimer->setEnabled(false);
    ui->btnResumeTimer->setEnabled(true);
}

void MainWindow::on_btnResumeTimer_clicked() {
    timerManager.resume();
    countdownTimer->start(1);
    ui->btnPauseTimer->setEnabled(true);
    ui->btnResumeTimer->setEnabled(false);
}

void MainWindow::on_btnResetTimer_clicked() {
    timerManager.reset();
    countdownTimer->stop();
    ui->btnStartTimer->setEnabled(true);
    ui->btnPauseTimer->setEnabled(false);
    ui->btnResumeTimer->setEnabled(false);
    ui->btnResetTimer->setEnabled(false);
    ui->timeEditTimer->setEnabled(true);
    ui->timeEditTimer->setTime(QTime(0, 0, 0));
}

void MainWindow::on_btnAddAlarm_clicked() {
    QTime alarmTime = ui->timeEditAlarm->time();
    QString label = ui->lineEditAlarmLabel->text().trimmed();

    if(label.isEmpty()) {
        label = "Alarm";
    }

    QDateTime now = QDateTime::currentDateTime();
    QDateTime alarmDateTime(now.date(), alarmTime);
    if (alarmDateTime < now) {
        alarmDateTime = alarmDateTime.addDays(1);
    }

    std::chrono::system_clock::time_point timePoint =
        std::chrono::system_clock::from_time_t(alarmDateTime.toSecsSinceEpoch());

    Alarm newAlarm{ timePoint, label.toStdString(), true };
    alarmManager.addAlarm(newAlarm);

    updateAlarmList();
    ui->lineEditAlarmLabel->clear();
}

void MainWindow::updateAlarmList() {
    ui->listWidgetAlarms->clear();

    const auto& alarms = alarmManager.getAllAlarms();
    for (const auto& alarm : alarms) {
        std::time_t tt = std::chrono::system_clock::to_time_t(alarm.time);
        QDateTime dt = QDateTime::fromSecsSinceEpoch(tt);
        QString timeStr = dt.time().toString("HH:mm");
        QString labelStr = QString::fromStdString(alarm.label);
        QString status = alarm.enabled ? "ON" : "OFF";

        QString itemText = QString("%1 - %2 [%3]").arg(timeStr, labelStr, status);
        ui->listWidgetAlarms->addItem(itemText);
    }
}

void MainWindow::checkAlarms() {
    alarmManager.checkAndTriggerAlarms();
    updateAlarmList();
}

void MainWindow::on_btnDeleteAlarms_clicked() {
    ui->listWidgetAlarms->clear();
    auto alarms = alarmManager.getAllAlarms();
    for (int i = alarms.size() - 1; i >= 0; --i) {
        alarmManager.removeAlarm(i);
    }
}

void MainWindow::onAlarmItemDoubleClicked(QListWidgetItem* item) {
    int index = ui->listWidgetAlarms->row(item);
    if(index >= 0 && index < alarmManager.getAllAlarms().size()) {
        alarmManager.toggleAlarm(index);
        updateAlarmList();
    }
}

void MainWindow::on_btnRemoveSelectedAlarm_clicked() {
    int index = ui->listWidgetAlarms->currentRow();
    if(index >=0&&index < alarmManager.getAllAlarms().size()) {
        alarmManager.removeAlarm(index);
        updateAlarmList();
    } else {
        QMessageBox::warning(this, "Warning", "No alarm selected.");
    }
}
