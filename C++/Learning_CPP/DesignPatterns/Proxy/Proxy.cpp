#include <iostream>
#include <memory>
#include <string>

class IBankAccount {
public:
	virtual void withdraw(double amount) = 0;
	virtual void deposit(double amount) = 0;
	virtual ~IBankAccount() = default;
};

class RealBankAccount : public IBankAccount {
private:
	double balance = 0;
public:
	void withdraw(double amount) override {
		if (amount <= balance) {
			balance -= amount;
			std::cout << "Withdrew $" << amount << ", remaining: $" << balance << "\n";
		}
		else {
			std::cout << "Insufficient funds!\n";
		}
	}

	void deposit(double amount) override {
		balance += amount;
		std::cout << "Deposited $" << amount << ", new balance: $" << balance << "\n";
	}
};



int main() {


	return 0;
}