#include <iostream>
#include <memory>
#include <string>

class ATM;

class ATMState {
public:
	virtual void insertCard(ATM& atm) = 0;
	virtual void enterPIN(ATM& atm, int pin) = 0;
	virtual void withdrawCash(ATM& atm, int amount) = 0;
	virtual ~ATMState() = default;
};



int main() {


	return 0;
}