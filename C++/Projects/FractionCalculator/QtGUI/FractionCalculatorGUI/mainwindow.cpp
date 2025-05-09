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
    connect(ui->btnEqual,&QPushButton::clicked,this,&MainWindow::onEqualClicked);
    connect(ui->btnLess,&QPushButton::clicked,this,&MainWindow::onLessClicked);
    connect(ui->btnMore,&QPushButton::clicked,this,&MainWindow::onMoreClicked);
    connect(ui->btnLessOrEqual, &QPushButton::clicked,this, &MainWindow::onLessOrEqualClicked);
    connect(ui->btnMoreOrEqual,&QPushButton::clicked,this,&MainWindow::onMoreOrEqualClicked);
    connect(ui->btnNotEqual, &QPushButton::clicked,this,&MainWindow::onNotEqualClicked);
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
    Fraction frac1 = getFraction1();
    Fraction frac2 = getFraction2();

    Fraction result = frac1 + frac2;

    setResult(QString::fromStdString(result.toString()));
}

void MainWindow::onSubClicked() {
    Fraction frac1 = getFraction1();
    Fraction frac2 = getFraction2();

    Fraction result = frac1 - frac2;

    setResult(QString::fromStdString(result.toString()));
}

void MainWindow::onMulClicked() {
    Fraction frac1 = getFraction1();
    Fraction frac2 = getFraction2();

    Fraction result = frac1 * frac2;

    setResult(QString::fromStdString(result.toString()));
}

void MainWindow::onDivClicked() {
    Fraction frac1 = getFraction1();
    Fraction frac2 = getFraction2();

    if(frac2.getNumerator() == 0) {
        QMessageBox::warning(this, "Error", "Dividing on zero!");
        return;
    }

    Fraction result = frac1 / frac2;

    setResult(QString::fromStdString(result.toString()));
}

void MainWindow::onPowClicked() {
    Fraction frac1 = getFraction1();
    Fraction frac2 = getFraction2();

    int exponent = frac2.getNumerator();
    Fraction result = frac1 ^ exponent;
    setResult(QString::fromStdString(result.toString()));
}

void MainWindow::onEqualClicked() {
    Fraction frac1 = getFraction1();
    Fraction frac2 = getFraction2();

    if (frac1 == frac2) {
        setResult("Equal");
    } else {
        setResult("Not equal");
    }
}

void MainWindow::onLessClicked() {
    Fraction frac1 = getFraction1();
    Fraction frac2 = getFraction2();

    if (frac1 < frac2) {
        setResult("Less");
    } else {
        setResult("More or equal");
    }
}

void MainWindow::onMoreClicked() {
    Fraction frac1 = getFraction1();
    Fraction frac2 = getFraction2();

    if (frac1 > frac2) {
        setResult("More");
    } else {
        setResult("Less or equal");
    }
}

void MainWindow::onMoreOrEqualClicked() {
    Fraction frac1 = getFraction1();
    Fraction frac2 = getFraction2();

    if(frac1 >= frac2) {
        setResult("More or equal");
    } else {
        setResult("Less");
    }
}

void MainWindow::onLessOrEqualClicked() {
    Fraction frac1 = getFraction1();
    Fraction frac2 = getFraction2();

    if(frac1 <= frac2) {
        setResult("Less or equal");
    } else {
        setResult("More");
    }
}

void MainWindow::onNotEqualClicked() {
    Fraction frac1 = getFraction1();
    Fraction frac2 = getFraction2();

    if (frac1 != frac2) {
        setResult("Not equal");
    } else {
        setResult("Equal");
    }
}
