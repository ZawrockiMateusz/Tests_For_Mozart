Feature: Skladniki
![Składniki](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
![](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
		W tym scenariuszu staram się
		Zmodyfikować wartości pól Typ 
		Oraz Punkty monitorowania
		W oknie Składniki

@ModifySkladniki
Scenario: Modify Skladniki 
	Given choose database 'MozartWinAppDriver'
	And log in as 'Szef' with '' password
	And accept product licence
	And open 'Składniki'
	And select a product with 'SMARTFON' code
	And change product type to 'Produkt'
	And set monitoring points to 'Półprodukt'
	Then I should see values 'P' as Type and 'Półprodukt' as Monitoring Point