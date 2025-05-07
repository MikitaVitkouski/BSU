#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "Fraction.h"
#include <QMessageBox>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    connect(ui->btnAdd,&QPushButton::clicked,this,&MainWindow::onAddClicked);
    connect(ui->btnSub,&QPushButton::clicked,this,&MainWindow::onSubClicked);
    connect(ui->btnMul,&QPushButton::clicked,this,&MainWindow::onMulClicked);
    connect(ui->btnDiv,&QPushButton::clicked,this,&MainWindow::onDivClicked);
    connect(ui->btnPow,&QPushButton::clicked,this,&MainWindow::onPowClicked);
    connect(ui->btnEqual,&QPushButton::clicked,this,&MainWindow::onEqualClicked);
    connect(ui->btnLess,&QPushButton::clicked,this,&MainWindow::onLessClicked);
    connect(ui->btnMore,&QPushButton::clicked,this,&MainWindow::onMoreClicked);

}

MainWindow::~MainWindow()
{
    delete ui;
}
