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

class ProtectedBankAccountProxy : public IBankAccount {
private:
	std::shared_ptr<RealBankAccount> realAccount;
	std::string password;

	bool authenticate() const {
		std::string input;
		std::cout << "Enter password: ";
		std::cin >> input;
		return input == password;
	}

public:
	ProtectedBankAccountProxy(std::shared_ptr<RealBankAccount> account, std::string pass) : realAccount(std::move(account)), password(std::move(pass)) { }

	void withdraw(double amount) override {
		if (authenticate()) {
			realAccount->withdraw(amount);
		}
		else {
			std::cout << "Access denied: wrong password.\n";
		}
	}

	void deposit(double amount) override {
		if (authenticate()) {
			realAccount->deposit(amount);
		}
		else {
			std::cout << "Access denied: wrong password.\n";
		}
	}
};

int main() {


	return 0;
}