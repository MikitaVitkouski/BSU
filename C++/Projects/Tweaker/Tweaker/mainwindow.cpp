#include "mainwindow.h"
#include "./ui_mainwindow.h"
#include <QDir>
#include <QProcess>
#include <QPixmap>
#include <QMessageBox>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    QDir directory = QDir::currentPath(); directory.cdUp(); directory.cdUp();
    QString basePath = directory.absolutePath();

    QFile fileStyle(basePath + QDir::separator() + "style.css");
    if (fileStyle.open(QFile::ReadOnly | QFile::Text)) {
        QTextStream stream(&fileStyle);
        QString styleSheet = stream.readAll();
        this->setStyleSheet(styleSheet);
        fileStyle.close();
    }

    // logos
    QString imagePath = basePath + QDir::separator() + "icons" + QDir::separator() + "resources" + QDir::separator() + "gear.png";
    QPixmap pixmap(imagePath);
    ui->logoGear->setPixmap(pixmap);
    ui->logoGear->setScaledContents(true);

    // RAM

    memoryUsagePercent = 0;

    ramTimer = new QTimer(this);
    connect(ramTimer, &QTimer::timeout, this, &MainWindow::updateMemoryUsage);
    ramTimer->start(1000);
    ramLabel = new RamLabel(this);
    ramLabel->setGeometry(510, 70, 150, 100);
    ramLabel->show();

    // buttons
    connect(ui->btnEasyMode, &QPushButton::clicked, this, &MainWindow::onbtnEasyModeClicked);
    connect(ui->btnMediumMode, &QPushButton::clicked, this, &MainWindow::onbtnMediumModeClicked);
    connect(ui->btnHardMode, &QPushButton::clicked, this, &MainWindow::onbtnHardModeClicked);
    connect(ui->btnExpertMode, &QPushButton::clicked, this, &MainWindow::onbtnExpertModeClicked);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void applyRegistryFile(const QString& regFilePath) {
    QProcess process;
    QString command {"regedit"};
    QStringList arguments{};
    arguments << "/s" << regFilePath;

    bool success = process.startDetached(command, arguments);
    if (!success) {
        qWarning("Cannot load regedit!");
    }
}

bool confirmRisk() {
    QMessageBox msgBox;
    msgBox.setIcon(QMessageBox::Warning);
    msgBox.setWindowTitle("Warning!");
    msgBox.setText("You are about to apply changes to the registry.\n"
                   "This may lead to unpredictable consequences.\n"
                   "Proceed at your own risk!\n\n"
                   "Do you want to continue?");
    msgBox.setStandardButtons(QMessageBox::Yes | QMessageBox::No);
    msgBox.setDefaultButton(QMessageBox::No);

    int ret {msgBox.exec()};
    return ret == QMessageBox::Yes;
}

void MainWindow::onbtnEasyModeClicked() {
    if(!confirmRisk()) return;

    QDir directory = QDir::currentPath(); directory.cdUp(); directory.cdUp();
    QString basePath = directory.absolutePath();
    applyRegistryFile(basePath + QDir::separator() + "easy.reg");
}

void MainWindow::onbtnMediumModeClicked() {
    if(!confirmRisk()) return;

    QDir directory = QDir::currentPath(); directory.cdUp(); directory.cdUp();
    QString basePath = directory.absolutePath();
    applyRegistryFile(basePath + QDir::separator() + "medium.reg");
}

void MainWindow::onbtnHardModeClicked() {
    if(!confirmRisk()) return;

    QDir directory = QDir::currentPath(); directory.cdUp(); directory.cdUp();
    QString basePath = directory.absolutePath();
    applyRegistryFile(basePath + QDir::separator() + "hard.reg");
}

void MainWindow::onbtnExpertModeClicked() {
    if(!confirmRisk()) return;

    QDir directory = QDir::currentPath(); directory.cdUp(); directory.cdUp();
    QString basePath = directory.absolutePath();
    applyRegistryFile(basePath + QDir::separator() + "expert.reg");
}

void MainWindow::updateMemoryUsage() {
    MEMORYSTATUSEX statex;
    statex.dwLength = sizeof(statex);
    GlobalMemoryStatusEx(&statex);
    memoryUsagePercent = static_cast<int>(statex.dwMemoryLoad);

    ramLabel->usage = memoryUsagePercent;
    ramLabel->update();
}
