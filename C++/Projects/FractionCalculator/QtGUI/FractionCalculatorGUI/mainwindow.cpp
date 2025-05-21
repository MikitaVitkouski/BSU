#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QMessageBox>
#include <QFile>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    QFile file("E:/Repositories/BSU/C++/Projects/FractionCalculator/QtGUI/FractionCalculatorGUI/style.css");
    if (file.open(QFile::ReadOnly | QFile::Text)) {
        QTextStream stream(&file);
        QString styleSheet = stream.readAll();
        this->setStyleSheet(styleSheet);
        file.close();
    }

    //connect (sender, signal, receiver, slot)
    connect(ui->btnAdd,&QPushButton::clicked,this,&MainWindow::onAddClicked);
    connect(ui->btnSub,&QPushButton::clicked,this,&MainWindow::onSubClicked);
    connect(ui->btnMul,&QPushButton::clicked,this,&MainWindow::onMulClicked);
    connect(ui->btnDiv,&QPushButton::clicked,this,&MainWindow::onDivClicked);
    connect(ui->btnPow,&QPushButton::clicked,this,&MainWindow::onPowClicked);
    connect(ui->btnEvaluate, &QPushButton::clicked, this, &MainWindow::onEvaluateClicked);
    connect(ui->btnLeftBracket,&QPushButton::clicked, this, &MainWindow::onLeftBracketClicked);
    connect(ui->btnRightBracket,&QPushButton::clicked, this, &MainWindow::onRightBracketClicked);
    connect(ui->btnOne,&QPushButton::clicked,this,&MainWindow::onOneClicked);
    connect(ui->btnTwo,&QPushButton::clicked,this,&MainWindow::onTwoClicked);
    connect(ui->btnThree,&QPushButton::clicked,this,&MainWindow::onThreeClicked);
    connect(ui->btnFour,&QPushButton::clicked,this,&MainWindow::onFourClicked);
    connect(ui->btnFive,&QPushButton::clicked,this,&MainWindow::onFiveClicked);
    connect(ui->btnSix,&QPushButton::clicked,this,&MainWindow::onSixClicked);
    connect(ui->btnSeven,&QPushButton::clicked,this,&MainWindow::onSevenClicked);
    connect(ui->btnEight,&QPushButton::clicked,this,&MainWindow::onEightClicked);
    connect(ui->btnNine,&QPushButton::clicked,this,&MainWindow::onNineClicked);
    connect(ui->btnZero,&QPushButton::clicked,this,&MainWindow::onZeroClicked);
    connect(ui->btnClear,&QPushButton::clicked,this,&MainWindow::onClearClicked);
    connect(ui->btnBackspace, &QPushButton::clicked, this,&MainWindow::onBackspaceClicked);
    connect(ui->btnToggleFormat, &QPushButton::clicked,this,&MainWindow::onToggleFormatClicked);
    connect(ui->btnReverse, &QPushButton::clicked,this,&MainWindow::onReverseClicked);
    connect(ui->btnSlash,&QPushButton::clicked,this,&MainWindow::onSlashClicked);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::setResult(const QString& result) {
    ui->labelResult->setText(result);
}

// These methods append symbols to lineEditExpression field

void MainWindow::onAddClicked() {
    ui->lineEditExpression->insert(" + ");
}

void MainWindow::onSubClicked() {
    ui->lineEditExpression->insert(" - ");
}

void MainWindow::onMulClicked() {
    ui->lineEditExpression->insert(" * ");
}

void MainWindow::onDivClicked() {
    ui->lineEditExpression->insert(" / ");
}

void MainWindow::onPowClicked() {
    ui->lineEditExpression->insert(" ^ ");
}

void MainWindow::onLeftBracketClicked() {
    ui->lineEditExpression->insert("( ");
}

void MainWindow::onRightBracketClicked() {
    ui->lineEditExpression->insert(" )");
}

void MainWindow::onOneClicked() {
    ui->lineEditExpression->insert("1");
}

void MainWindow::onTwoClicked() {
    ui->lineEditExpression->insert("2");
}

void MainWindow::onThreeClicked() {
    ui->lineEditExpression->insert("3");
}

void MainWindow::onFourClicked() {
    ui->lineEditExpression->insert("4");
}

void MainWindow::onFiveClicked() {
    ui->lineEditExpression->insert("5");
}

void MainWindow::onSixClicked() {
    ui->lineEditExpression->insert("6");
}

void MainWindow::onSevenClicked() {
    ui->lineEditExpression->insert("7");
}

void MainWindow::onEightClicked() {
    ui->lineEditExpression->insert("8");
}

void MainWindow::onNineClicked() {
    ui->lineEditExpression->insert("9");
}

void MainWindow::onZeroClicked() {
    ui->lineEditExpression->insert("0");
}

void MainWindow::onClearClicked() {
    ui->lineEditExpression->clear();
    ui->labelResult->clear();
}

void MainWindow::onBackspaceClicked() {
    QString text = ui->lineEditExpression->text();
    if (!text.isEmpty()) {
        text.chop(1); // deletes last symbol
        ui->lineEditExpression->setText(text);
    }
}

void MainWindow::onToggleFormatClicked() {
    if (showingAsDecimal) {
        // Show a fraction expression
        ui->labelResult->setText(QString::fromStdString(lastResult.toString()));
        ui->btnToggleFormat->setText("→ double");
        showingAsDecimal = false;
    } else {
        // Show a decimal expression
        ui->labelResult->setText(QString::number(lastResult.toDouble(), 'f', 6));
        ui->btnToggleFormat->setText("→ fraction");
        showingAsDecimal = true;
    }
}

// Evaluate the expression when the "Evaluate" button is clicked
void MainWindow::onEvaluateClicked() {
    QString expr = ui->lineEditExpression->text();
    try {
        lastResult = parseExpression(expr);
        Fraction result = parseExpression(expr);
        setResult(QString::fromStdString(result.toString()));
    } catch (const std::exception& e) {
        QMessageBox::critical(this,"Error",e.what());
    }
    showingAsDecimal = false;
    ui->btnToggleFormat->setText("→ double");
}

void MainWindow::onReverseClicked() {
    try {
        if (lastResult.getNumerator() == 0) {
            throw std::runtime_error("Can't reverse fraction with zero numerator.");
        }

        lastResult = lastResult.reverse();

        if (showingAsDecimal) {
            ui->labelResult->setText(QString::number(lastResult.toDouble(), 'f', 6));
        } else {
            ui->labelResult->setText(QString::fromStdString(lastResult.toString()));
        }

    } catch (const std::exception& e) {
        QMessageBox::critical(this, "Error", e.what());
    }
}

void MainWindow::onSlashClicked() {
    ui->lineEditExpression->insert("/");
}
