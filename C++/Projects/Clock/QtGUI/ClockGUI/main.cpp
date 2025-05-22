#include "mainwindow.h"

#include <QApplication>
#include <QIcon>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    a.setWindowIcon(QIcon(":/icons/resources/clockapp.png"));
    MainWindow w;
    w.setWindowIcon(QIcon(":/resources/clockapp.png"));
    w.show();
    return a.exec();
}
