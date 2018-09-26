pragma solidity 0.4.23;

import "./Product.sol";

contract Transaction {
	address private buyer;
	Product private product;
	uint private quantity;
	uint private date;
	uint private shippingTime;
	string private description;

	/// @param _buyer The address of buyer
	/// @param _product Address of product to buy
	/// @param _quantity Number of products to buy
	/// @param _date Unix date of transaction emmited
	/// @param _description Details of transaction
	constructor(address _buyer, address _product, uint _quantity, uint _date, string _description) public {
		require(_buyer != 0);
		require(_product != 0);
		require(_quantity != 0);
		require(_date != 0);
		require(bytes(_description).length != 0);

		buyer = _buyer;
		product = Product(_product);
		quantity = _quantity;
		date = _date;
		description = _description;

		require(product.isActive());
	}

	/// @notice Get the product buyer
	/// @return Buyer address
	function getBuyer() external view returns(address) {
		return buyer;
	}

	/// @notice Get the product seller
	/// @return Product seller address
	function getSeller() external view returns(address) {
		return product.getSeller();
	}

	/// @notice Get the total price of transaction
	/// @return Total price of transaction
	function getPrice() external view returns(uint) {
		return product.getPrice() * quantity;
	}

	/// @notice Get product of transaction
	/// @return Product object
	function getProduct() external view returns(Product) {
		return product;
	}

	/// @notice Get the quantity of products purchased
	/// @return Quantity of products purchased
	function getQuanity() external view returns(uint) {
		return quantity;
	}

	/// @notice Get the date of the transaction
	/// @return Unix date when the transaction was executed
	function getDate() external view returns(uint) {
		return date;
	}

	/// @notice Get the shipping time of the transaction represented in secconds
	/// @return Transaction Shipping time represented in secconds
	function getShippingTime() external view returns(uint) {
		return shippingTime;
	}

	/// @notice Get the description of the transaction
	/// @return Transaction description
	function getDescription() external view returns(string) {
		return description;
	}
}