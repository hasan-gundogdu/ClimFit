-- WeatherLog ekle
INSERT INTO WeatherLog (Date, Location, Temperature, Description, WindSpeed, IsDeleted, IsActive, CreatorUserId, CreatedDate)
VALUES 
(GETDATE(), 'Ankara', 14.5, 'Rainy', 18.2, 0, 1, 'A1B2C3D4-E5F6-7890-1234-56789ABCDEF0', GETDATE());

-- ClothingItems ekle
INSERT INTO ClothingItem (Name, Category, Material, Color, ImageUrl, Notes, UserId, IsDeleted, IsActive, CreatorUserId, CreatedDate)
VALUES 
('Siyah Mont', 0, 3, 'Black', NULL, 'Su geçirmez', 'A1B2C3D4-E5F6-7890-1234-56789ABCDEF0', 0, 1, 'A1B2C3D4-E5F6-7890-1234-56789ABCDEF0', GETDATE()),
('Kot Pantolon', 1, 4, 'Blue', NULL, 'Slim fit', 'A1B2C3D4-E5F6-7890-1234-56789ABCDEF0', 0, 1, 'A1B2C3D4-E5F6-7890-1234-56789ABCDEF0', GETDATE()),
('Beyaz Tiþört', 0, 0, 'White', NULL, 'Yazlýk', 'A1B2C3D4-E5F6-7890-1234-56789ABCDEF0', 0, 1, 'A1B2C3D4-E5F6-7890-1234-56789ABCDEF0', GETDATE());

-- OutfitSuggestion ekle
INSERT INTO OutfitSuggestion (UserId, WeatherLogId, SuggestedText, IsLiked, IsDeleted, IsActive, CreatorUserId, CreatedDate)
VALUES 
(
    'A1B2C3D4-E5F6-7890-1234-56789ABCDEF0', 
    (SELECT TOP 1 Id FROM WeatherLog ORDER BY CreatedDate DESC),
    'Bugün için siyah mont, beyaz tiþört ve kot pantolon kombinasyonu uygundur.', 
    0, 0, 1, 'A1B2C3D4-E5F6-7890-1234-56789ABCDEF0', GETDATE()
);

-- OutfitItems ekle
INSERT INTO OutfitItem (OutfitSuggestionId, ClothingItemId, IsDeleted, IsActive, CreatorUserId, CreatedDate)
VALUES
(
    (SELECT TOP 1 Id FROM OutfitSuggestion ORDER BY CreatedDate DESC),
    (SELECT Id FROM ClothingItem WHERE Name = 'Siyah Mont'),
    0, 1, 'A1B2C3D4-E5F6-7890-1234-56789ABCDEF0', GETDATE()
),
(
    (SELECT TOP 1 Id FROM OutfitSuggestion ORDER BY CreatedDate DESC),
    (SELECT Id FROM ClothingItem WHERE Name = 'Kot Pantolon'),
    0, 1, 'A1B2C3D4-E5F6-7890-1234-56789ABCDEF0', GETDATE()
),
(
    (SELECT TOP 1 Id FROM OutfitSuggestion ORDER BY CreatedDate DESC),
    (SELECT Id FROM ClothingItem WHERE Name = 'Beyaz Tiþört'),
    0, 1, 'A1B2C3D4-E5F6-7890-1234-56789ABCDEF0', GETDATE()
);
