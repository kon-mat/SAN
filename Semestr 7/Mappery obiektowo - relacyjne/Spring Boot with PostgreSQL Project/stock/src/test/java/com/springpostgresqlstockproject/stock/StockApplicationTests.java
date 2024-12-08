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

    @Autowired
    private LocationRepository locationRepository;

    @Test
    void contextLoads() {
    }

    @Test
    @Transactional
    public void testAddItemWithLocation() {
        // Dodanie nowej lokalizacji
        Location location = new Location(null, 1, 2, 3);
        Location savedLocation = locationRepository.save(location);

        assertNotNull(savedLocation);
        assertEquals(1, savedLocation.getLocRow());
        assertEquals(2, savedLocation.getLocColumn());
        assertEquals(3, savedLocation.getLocShelf());

        // Dodanie przedmiotu powiązanego z lokalizacją
        Item item = new Item(null, "1234567890123", "BrandWithLocation", "M", "Green", savedLocation.getId().intValue());
        Item savedItem = itemRepository.save(item);

        assertNotNull(savedItem);
        assertEquals("BrandWithLocation", savedItem.getBrand());
        assertEquals(savedLocation.getId().intValue(), savedItem.getLocationId());
    }

    @Test
    @Transactional
    public void testAddAndRetrieveItem() {
        Item item = new Item(null, "9876543210123", "TestBrand", "L", "Red", 1);
        Item savedItem = itemRepository.save(item);

        assertNotNull(savedItem);
        assertEquals("TestBrand", savedItem.getBrand());

        Item retrievedItem = itemRepository.findById(savedItem.getId()).orElse(null);
        assertNotNull(retrievedItem);
        assertEquals("TestBrand", retrievedItem.getBrand());
    }

    @Test
    @Transactional
    public void testDeleteItem() {
        // Dodanie elementu
        Item item = new Item(null, "5555555555555", "DeleteBrand", "S", "Yellow", 1);
        Item savedItem = itemRepository.save(item);

        // Usunięcie elementu
        itemRepository.deleteById(savedItem.getId());

        // Sprawdzenie czy element został usunięty
        boolean exists = itemRepository.findById(savedItem.getId()).isPresent();
        assertFalse(exists);
    }

    @Test
    @Transactional
    public void testRetrieveLocation() {
        Location location = new Location(null, 3, 4, 5);
        Location savedLocation = locationRepository.save(location);

        Location retrievedLocation = locationRepository.findById(savedLocation.getId()).orElse(null);
        assertNotNull(retrievedLocation);
        assertEquals(3, retrievedLocation.getLocRow());
        assertEquals(4, retrievedLocation.getLocColumn());
        assertEquals(5, retrievedLocation.getLocShelf());
    }
}
