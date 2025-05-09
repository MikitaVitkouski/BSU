#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QMessageBox>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    QString styleSheet = R"(
    QWidget {
        background-color: #fdfdfd;
        color: #333333;
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
        font-size: 18px;
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

    QPushButton#btnEvaluate {
        background-color: #ff6600;
        color: white;
        font-weight: bold;
    }

    QPushButton#btnClear {
        background-color: #ff6600;
        color: white;
        font-weight: bold;
    }

    QPushButton#btnSlash, QPushButton#btnMul, QPushButton#btnDiv, QPushButton#btnAdd, QPushButton#btnSub, QPushButton#btnPow {
        color: #ff6600;
    }
)";
    this->setStyleSheet(styleSheet);

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
    connect(ui->btnSlash,&QPushButton::clicked,this,&MainWindow::onSlashClicked);
    connect(ui->btnBackspace, &QPushButton::clicked, this,&MainWindow::onBackspaceClicked);
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
    ui->lineEditExpression->insert("/");
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

void MainWindow::onSlashClicked() {
    ui->lineEditExpression->insert("/");
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

// Evaluate the expression when the "Evaluate" button is clicked
void MainWindow::onEvaluateClicked() {
    QString expr = ui->lineEditExpression->text();
    try {
        Fraction result = parseExpression(expr);
        setResult(QString::fromStdString(result.toString()));
    } catch (const std::exception& e) {
        QMessageBox::critical(this,"Error",e.what());
    }
}
