pragma solidity 0.4.23;

contract Product {
	address private owner;
	address private seller;
	string private name;
	uint private price;
	string private description;
	uint private created_at;
	uint private removed_at;

	// Emitted when the product won't be used in the following transactions
	event LogRemove(uint date, address from);

	/// @param _seller The address of seller
	/// @param _name The name of the product
	/// @param _price The price of the product
	/// @param _description Details of product
	/// @param _created_at Unix date of product creation
	constructor(address _seller, string _name, uint _price, string _description, uint _created_at) public {
		require(_seller != 0);
		require(bytes(_name).length != 0);
		require(_price != 0);
		require(bytes(_description).length != 0);
		require(_created_at != 0);

		seller = _seller;
		name = _name;
		price = _price;
		description = _description;
		created_at = _created_at;

		owner = msg.sender;
	}

	/// @notice Set the product as inactive
	/// @dev Emit 'LogRemove'
	/// @param _removed_at Unix date of product deletion
	/// @return If it was removed correctly
	function remove(uint _removed_at) external returns(bool) {
		require(owner == msg.sender);
		require(_removed_at != 0);

		removed_at = _removed_at;

		emit LogRemove(_removed_at, msg.sender);

		return true;
	}

	/// @notice Get if the product can be used
	/// @return If is active to use
	function isActive() external view returns(bool) {
		return removed_at != 0;
	}

	/// @notice Get the seller
	/// @return Seller address
	function getSeller() external view returns(address) {
		return seller;
	}

	/// @notice Get the name of the product
	/// @return Product
	function getName() external view returns(string) {
		return name;
	}

	/// @notice Get the price of the product
	/// @return Product
	function getPrice() external view returns(uint) {
		return price;
	}

	/// @notice Get the description of the product
	/// @return Product description
	function getDescription() external view returns(string) {
		return description;
	}

	/// @notice Get the date when the product was created
	/// @return Unix date when the product was created
	function getCreatedAt() external view returns(uint) {
		return created_at;
	}

	/// @notice Get the date when the product was removed
	/// @return Unix date when the product was removed
	function getRemovedAt() external view returns(uint) {
		return removed_at;
	}
}