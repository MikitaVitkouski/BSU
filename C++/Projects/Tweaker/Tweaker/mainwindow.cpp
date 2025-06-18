#include "mainwindow.h"
#include "./ui_mainwindow.h"
#include <QDir>
#include <QProcess>

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

void MainWindow::onbtnEasyModeClicked() {
    QDir directory = QDir::currentPath(); directory.cdUp(); directory.cdUp();
    QString basePath = directory.absolutePath();
    applyRegistryFile(basePath + QDir::separator() + "easy.reg");
}

void MainWindow::onbtnMediumModeClicked() {
    QDir directory = QDir::currentPath(); directory.cdUp(); directory.cdUp();
    QString basePath = directory.absolutePath();
    applyRegistryFile(basePath + QDir::separator() + "medium.reg");
}

void MainWindow::onbtnHardModeClicked() {
    QDir directory = QDir::currentPath(); directory.cdUp(); directory.cdUp();
    QString basePath = directory.absolutePath();
    applyRegistryFile(basePath + QDir::separator() + "hard.reg");
}

void MainWindow::onbtnExpertModeClicked() {
    QDir directory = QDir::currentPath(); directory.cdUp(); directory.cdUp();
    QString basePath = directory.absolutePath();
    applyRegistryFile(basePath + QDir::separator() + "expert.reg");
}
