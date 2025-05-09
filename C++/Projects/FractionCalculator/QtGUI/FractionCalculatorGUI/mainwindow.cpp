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
        background-color: #1e1e1e;
        color: #ffffff;
        font-family: Segoe UI, sans-serif;
        font-size: 16px;
    }

    QLineEdit {
        background-color: #2a2a2a;
        color: #f0f0f0;
        border: 2px solid #ffaa00;
        border-radius: 8px;
        padding: 5px;
    }

    QLabel {
        color: #a0ffb3;
        font-weight: bold;
    }

    QPushButton {
        background-color: #ffaa00;
        color: #1e1e1e;
        border: none;
        border-radius: 6px;
        padding: 6px 12px;
    }

    QPushButton:hover {
        background-color: #ffcc66;
    }

    QPushButton:pressed {
        background-color: #ff9900;
    }

    QPushButton#btnClear {
        background-color: #ff4d4d;
        color: white;
    }

    QPushButton#btnEvaluate {
        background-color: #00cc66;
        color: white;
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
