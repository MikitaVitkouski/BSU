#include <iostream>
#include <memory>
#include <string>

class IPaymentProcessor {
public:
	virtual void pay(double amount) = 0;
	virtual ~IPaymentProcessor() = default;
};

class BankPaymentService {
public:
	void makeTransaction(double value, const std::string& currency) {
		std::cout << "Processing bank transaction: " << value << " " << currency << "\n";
	}
};

class BankPaymentAdapter : public IPaymentProcessor {
private:
	std::shared_ptr<BankPaymentService> service;
public:
	BankPaymentAdapter(std::shared_ptr<BankPaymentService> srv) : service(std::move(srv)) { }

	void pay(double amount) override {
		service->makeTransaction(amount, "USD");
	}
};

class Store {
private:
	std::shared_ptr<IPaymentProcessor> paymentProcessor;
public:
	Store(std::shared_ptr<IPaymentProcessor> processor) : paymentProcessor(std::move(processor)) {} 

	void purchase(double price) {
		std::cout << "Customer is purchasing goods worth $" << price << "\n";
		paymentProcessor->pay(price);
	}
};

int main() {
	auto bankService = std::make_shared<BankPaymentService>();
	auto adapter = std::make_shared<BankPaymentAdapter>(bankService);

	Store myStore(adapter);
	myStore.purchase(99.99);

	return 0;
}