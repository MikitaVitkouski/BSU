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

class NoCardState : public ATMState {
	void insertCard(ATM& atm) override;
	void enterPIN(ATM& atm, int) override {
		std::cout << "Insert card first.\n";
	}
	void withdrawCash(ATM& atm, int) override {
		std::cout << "Insert card first.\n";
	}
};

class HasCardState : public ATMState {
public:
	void insertCard(ATM& atm) override {
		std::cout << "Card already inserted.\n";
	}

	void enterPIN(ATM& atm, int pin) override;
	void withdrawCash(ATM& atm, int) override {
		std::cout << "Enter PIN first.\n";
	}
};

class AuthenticatedState : public ATMState {
public:
	void insertCard(ATM& atm) override {
		std::cout << "Already authenticated.\n";
	}

	void enterPIN(ATM& atm, int) override {
		std::cout << "Already entered PIN.\n";
	}

	void withdrawCash(ATM& atm, int amount) override;
};

int main() {


	return 0;
}