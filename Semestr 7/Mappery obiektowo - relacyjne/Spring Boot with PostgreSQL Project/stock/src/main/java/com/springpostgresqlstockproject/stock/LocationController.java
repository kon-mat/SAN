package com.springpostgresqlstockproject.stock;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/locations")
public class LocationController {

    @Autowired
    private LocationRepository locationRepository;

    @GetMapping("")
    public List<Location> getAllLocations() {
        return locationRepository.findAll();
    }

    @GetMapping("/{id}")
    public Location getLocationById(@PathVariable("id") int id) {
        return locationRepository.findById(id).orElse(null);
    }

    @PostMapping("")
    public Location addLocation(@RequestBody Location location) {
        return locationRepository.save(location);
    }

    @PutMapping("/{id}")
    public Location updateLocation(@PathVariable("id") int id, @RequestBody Location updatedLocation) {
        return locationRepository.findById(id).map(location -> {
            location.setLocRow(updatedLocation.getLocRow());
            location.setLocColumn(updatedLocation.getLocColumn());
            location.setLocShelf(updatedLocation.getLocShelf());
            return locationRepository.save(location);
        }).orElse(null);
    }

    @DeleteMapping("/{id}")
    public void deleteLocation(@PathVariable("id") int id) {
        locationRepository.deleteById(id);
    }
}
