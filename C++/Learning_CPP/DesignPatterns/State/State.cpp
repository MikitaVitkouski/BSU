#include <iostream>
#include <memory>
#include <string>

class ATM;

// State
class ATMState {
public:
	virtual void insertCard(ATM& atm) = 0;
	virtual void enterPIN(ATM& atm, int pin) = 0;
	virtual void withdrawCash(ATM& atm, int amount) = 0;
	virtual ~ATMState() = default;
};

// Concrete states
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

// Context
class ATM {
private:
	std::unique_ptr<ATMState> currentState;
	friend class NoCardState;
	friend class HasCardState;
	friend class AuthenticatedState;
public:
	ATM() {
		currentState = std::make_unique<NoCardState>();
	}

	void setState(std::unique_ptr<ATMState> state) {
		currentState = std::move(state);
	}

	void insertCard() {
		currentState->insertCard(*this);
	}

	void enterPIN(int pin) {
		currentState->enterPIN(*this, pin);
	}

	void withdrawCash(int amount) {
		currentState->withdrawCash(*this, amount);
	}
};

void NoCardState::insertCard(ATM& atm) {
	std::cout << "Card inserted.\n";
	atm.setState(std::make_unique<HasCardState>());
}

void HasCardState::enterPIN(ATM& atm, int pin) {
	if (pin == 1234) {
		std::cout << "PIN correct.\n";
		atm.setState(std::make_unique<AuthenticatedState>());
	}
	else {
		std::cout << "Incorrect PIN.\n";
	}
}

void AuthenticatedState::withdrawCash(ATM& atm, int amount) {
	std::cout << "Dispensing $" << amount << ".\n";
	std::cout << "Transaction complete.\n";
	atm.setState(std::make_unique<NoCardState>());
}

int main() {
	ATM atm;

	atm.withdrawCash(100); //Can't withdraw yet
	atm.enterPIN(1234); //No card yet
	atm.insertCard(); //Insert card
	atm.enterPIN(1234); //Enter correct PIN
	atm.withdrawCash(200);	 //Withdraw money

	/*Output:
	Insert card first.
	 card first.
	Card inserted.
	PIN correct.
	Dispensing $200.
	Transaction complete.
	*/

	return 0;
}
