#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "Fraction.h"
#include "ExpressionParser.h"

QT_BEGIN_NAMESPACE
namespace Ui {
class MainWindow;
}
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
private slots:
    void onAddClicked();
    void onSubClicked();
    void onMulClicked();
    void onDivClicked();
    void onPowClicked();
    void onEvaluateClicked();
    void onLeftBracketClicked();
    void onRightBracketClicked();
    void onOneClicked();
    void onTwoClicked();
    void onThreeClicked();
    void onFourClicked();
    void onFiveClicked();
    void onSixClicked();
    void onSevenClicked();
    void onEightClicked();
    void onNineClicked();
    void onZeroClicked();
    void onClearClicked();
    void onBackspaceClicked();
    void onToggleFormatClicked();
    void onReverseClicked();
    void onSlashClicked();

private:
    Ui::MainWindow *ui;
    Fraction lastResult;
    bool showingAsDecimal = false;
    void setResult(const QString& result);
};
#endif // MAINWINDOW_H
