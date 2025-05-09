#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "Fraction.h"
#include <QMessageBox>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    //connect (sender, signal, receiver, slot)
    connect(ui->btnAdd,&QPushButton::clicked,this,&MainWindow::onAddClicked);
    connect(ui->btnSub,&QPushButton::clicked,this,&MainWindow::onSubClicked);
    connect(ui->btnMul,&QPushButton::clicked,this,&MainWindow::onMulClicked);
    connect(ui->btnDiv,&QPushButton::clicked,this,&MainWindow::onDivClicked);
    connect(ui->btnPow,&QPushButton::clicked,this,&MainWindow::onPowClicked);
    connect(ui->btnEvaluate, &QPushButton::clicked, this, &MainWindow::onEvaluateClicked);
}

MainWindow::~MainWindow()
{
    delete ui;
}

Fraction MainWindow::getFraction1() const {
    int num = ui->lineEditNum1->text().toInt();
    int den = ui->lineEditDen1->text().toInt();
    return Fraction(num, den);
}

Fraction MainWindow::getFraction2() const {
    int num = ui->lineEditNum2->text().toInt();
    int den = ui->lineEditDen2->text().toInt();
    return Fraction(num, den);
}

void MainWindow::setResult(const QString& result) {
    ui->labelResult->setText(result);
}

void MainWindow::onAddClicked() {
    // Append '+' to the expression in the lineEdit
    ui->lineEditExpression->insert("+");
}

void MainWindow::onSubClicked() {
    // Append '-' to the expression in the lineEdit
    ui->lineEditExpression->insert("-");
}

void MainWindow::onMulClicked() {
    // Append '*' to the expression in the lineEdit
    ui->lineEditExpression->insert("*");
}

void MainWindow::onDivClicked() {
    // Append '/' to the expression in the lineEdit
    ui->lineEditExpression->insert("/");
}

void MainWindow::onPowClicked() {
    // Append '^' to the expression in the lineEdit
    ui->lineEditExpression->insert("^");
}

// Evaluate the expression when the "Evaluate" button is clicked
void MainWindow::onEvaluateClicked() {
    QString expr = ui->lineEditExpression->text();
    try {
        Fraction result = evaluate(expr);
        setResult(QString::fromStdString(result.toString()));
    } catch (const std::exception& e) {
        QMessageBox::critical(this,"Error",e.what());
    }
}
