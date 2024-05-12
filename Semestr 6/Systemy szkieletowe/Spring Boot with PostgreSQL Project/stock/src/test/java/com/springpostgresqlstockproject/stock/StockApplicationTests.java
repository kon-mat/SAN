package com.springpostgresqlstockproject.stock;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.dao.EmptyResultDataAccessException;
import org.springframework.transaction.annotation.Transactional;

import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
class StockApplicationTests {

	@Autowired
	private ItemRepository itemRepository;

	@Test
	void contextLoads() {
	}

	@Test
	public void testGetAllItems() {
		// Pobieramy wszystkie elementy i sprawdzamy czy ich liczba się zgadza (8 dodanych rekordów wraz z tworzeniem bazy)
		assertEquals(8, itemRepository.getAllItems().size());
	}

	@Test
	public void testGetItemById() {
		// Pobieramy element na podstawie jego identyfikatora i sprawdzamy czy jest niepusty oraz czy identyfikator się zgadza
		Item retrievedItem = itemRepository.getItemById(1);
		assertNotNull(retrievedItem);
		assertEquals(1, retrievedItem.getId());
	}

	@Test
	public void testUpdateItem() {
		// Aktualizujemy dane elementu
		Item updatedItem = new Item(1, "2222222222", "Nike", "M", "red", 3);
		itemRepository.updateItem(updatedItem);

		// Pobieramy zaktualizowany element i sprawdzamy czy dane się zgadzają
		Item retrievedItem = itemRepository.getItemById(1);
		assertNotNull(retrievedItem);
		assertEquals("2222222222", retrievedItem.getEan());
		assertEquals("Nike", retrievedItem.getBrand());
		assertEquals("M", retrievedItem.getSize());
		assertEquals("red", retrievedItem.getColor());
		assertEquals(3, retrievedItem.getLocationId());
	}

	@Test
	public void testDeleteItem() {
		// Usuwamy element
		itemRepository.deleteItem(2);

		// Sprawdzamy czy element został usunięty poprzez próbę pobrania go z bazy danych
		Item deletedItem = null;
		try {
			deletedItem = itemRepository.getItemById(2);
		} catch (EmptyResultDataAccessException e) {
			// Ignorujemy wyjątek, ponieważ oczekujemy, że element nie zostanie znaleziony
		}
		assertNull(deletedItem);
	}


	@Test
	@Transactional
	public void testAddItemToStockSuccess() {
		Item item = new Item(5000, "1111111111", "Levis", "S", "blue", 4);
		int result = itemRepository.addItemToStock(item);
		assertEquals(1, result); // Sprawdzamy czy dodano 1 wiersz do tabeli item
	}

	@Test
	@Transactional
	public void testAddItemToStockFailure() {
		// Próbujemy dodać element, który spowoduje błąd (duplikat klucza głównego)
		Item item1 = new Item(6000, "0000000000", "Jordan", "L", "white", 1);
		Item item2 = new Item(6000, "0000000000", "Error", "ERR", "error", 1);
		itemRepository.addItemToStock(item1);
		// Spodziewamy się rzucenia wyjątku i cofnięcia transakcji przy próbie dodania kolejnego elementu
		assertThrows(RuntimeException.class, () -> itemRepository.addItemToStock(item2));
	}

}
