#ifndef EXPRESSIONPARSER_H
#define EXPRESSIONPARSER_H

#include "Fraction.h"
#include <QString>
#include <QStringList>
#include <QVector>

Fraction parseExpression(const QString& expression);

#endif // EXPRESSIONPARSER_H
