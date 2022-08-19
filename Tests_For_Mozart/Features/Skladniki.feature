Feature: Skladniki
#![Składniki]()
#![]()
	#W tym scenariuszu staram się zmodyfikować wartości pól Typ oraz Punkty monitorowania w oknie Składniki

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