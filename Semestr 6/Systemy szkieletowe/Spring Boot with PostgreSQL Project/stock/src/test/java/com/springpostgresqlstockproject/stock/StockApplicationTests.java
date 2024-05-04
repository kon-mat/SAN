package com.springpostgresqlstockproject.stock;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.transaction.annotation.Transactional;
import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

@SpringBootTest
class StockApplicationTests {

	@Autowired
	private ItemRepository itemRepository;

	@Test
	void contextLoads() {
	}

	@Test
	@Transactional
	public void testAddItemToStockSuccess() {
		Item item = new Item(111, "1111111111", "Levis", "S", "blue", 4);
		int result = itemRepository.addItemToStock(item);
		assertEquals(1, result); // Sprawdzamy czy dodano 1 wiersz do tabeli item
	}

	@Test
	@Transactional
	public void testAddItemToStockFailure() {
		// Próbujemy dodać element, który spowoduje błąd (np. duplikat klucza głównego)
		Item item1 = new Item(222, "0000000000", "Jordan", "L", "white", 1);
		Item item2 = new Item(222, "0000000000", "Error", "ERR", "error", 1);
		itemRepository.addItemToStock(item1);
		// Spodziewamy się rzucenia wyjątku i cofnięcia transakcji przy próbie dodania kolejnego elementu
		assertThrows(RuntimeException.class, () -> itemRepository.addItemToStock(item2));
	}

}
