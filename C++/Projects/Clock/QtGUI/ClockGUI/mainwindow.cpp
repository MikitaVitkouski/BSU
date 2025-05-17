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
    ui->comboBoxTimezone->addItem("London (UTC+0)", "Europe/London");
    ui->comboBoxTimezone->addItem("Moscow (UTC+3)", "Europe/Moscow");
    ui->comboBoxTimezone->addItem("Tokyo (UTC+9)", "Asia/Tokyo");
    ui->comboBoxTimezone->addItem("New York (UTC-5)", "America/New_York");
    ui->comboBoxTimezone->addItem("Baker Island (UTC−12)", "Etc/GMT+12");
    ui->comboBoxTimezone->addItem("American Samoa (UTC−11)", "Pacific/Pago_Pago");
    ui->comboBoxTimezone->addItem("Honolulu (UTC−10)", "Pacific/Honolulu");
    ui->comboBoxTimezone->addItem("Anchorage (UTC−9)", "America/Anchorage");
    ui->comboBoxTimezone->addItem("Los Angeles (UTC−8)", "America/Los_Angeles");
    ui->comboBoxTimezone->addItem("Denver (UTC−7)", "America/Denver");
    ui->comboBoxTimezone->addItem("Mexico City (UTC−6)", "America/Mexico_City");
    ui->comboBoxTimezone->addItem("New York (UTC−5)", "America/New_York");
    ui->comboBoxTimezone->addItem("Santiago (UTC−4)", "America/Santiago");
    ui->comboBoxTimezone->addItem("Buenos Aires (UTC−3)", "America/Argentina/Buenos_Aires");
    ui->comboBoxTimezone->addItem("South Georgia (UTC−2)", "Atlantic/South_Georgia");
    ui->comboBoxTimezone->addItem("Azores (UTC−1)", "Atlantic/Azores");
    ui->comboBoxTimezone->addItem("London (UTC+0)", "Europe/London");
    ui->comboBoxTimezone->addItem("Reykjavik (UTC+0)", "Atlantic/Reykjavik");
    ui->comboBoxTimezone->addItem("Paris (UTC+1)", "Europe/Paris");
    ui->comboBoxTimezone->addItem("Berlin (UTC+1)", "Europe/Berlin");
    ui->comboBoxTimezone->addItem("Cairo (UTC+2)", "Africa/Cairo");
    ui->comboBoxTimezone->addItem("Johannesburg (UTC+2)", "Africa/Johannesburg");
    ui->comboBoxTimezone->addItem("Moscow (UTC+3)", "Europe/Moscow");
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

void MainWindow::on_btnPlayStopwatch_clicked() {
    stopwatch.start();
    stopwatchTimer->start(100); // updating timer each 100 ms
}

void MainWindow::on_btnPauseStopwatch_clicked() {
    if(stopwatch.isRunning()) {
        stopwatch.pause();
        stopwatchTimer->stop();
    } else {
        stopwatch.resume();
        stopwatchTimer->start(100);
    }
}

void MainWindow::on_btnResetStopwatch_clicked() {
    stopwatch.reset();
    stopwatchTimer->stop();
    ui->labelTimeStopwatch->setText("00:00:00.000");
}

void MainWindow::on_btnAddLap_clicked() {

}
