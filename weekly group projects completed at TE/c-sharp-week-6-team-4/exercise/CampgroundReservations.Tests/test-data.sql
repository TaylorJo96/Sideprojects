CREATE TABLE park (
  park_id integer identity NOT NULL,
  name varchar(80) NOT NULL,          -- Name of the park
  location varchar(50) NOT NULL,      -- State name(s) where park is located
  establish_date date NOT NULL,       -- Date park was established
  area integer NOT NULL,              -- Area in acres
  visitors integer NOT NULL,          -- Latest recorded number of annual visitors
  description varchar(500) NOT NULL,  --
  CONSTRAINT pk_park_park_id PRIMARY KEY (park_id)
);

CREATE TABLE campground (
  campground_id integer identity NOT NULL,
  park_id integer NOT NULL,            -- ID of park the campground is at
  name varchar(80) NOT NULL,           -- Name of the campground
  open_from_mm integer NOT NULL,       -- Campground is open from month: 01=January, 02=February, ... 12=December
  open_to_mm integer NOT NULL,         -- Campground is open to month: 01=January, 02=February, ... 12=December
  daily_fee decimal(13,2) NOT NULL,
  CONSTRAINT pk_campground_campground_id PRIMARY KEY (campground_id),
  CONSTRAINT fk_campground_park FOREIGN KEY (park_id) REFERENCES park(park_id)
);

CREATE TABLE site (
  site_id integer identity NOT NULL,
  campground_id integer NOT NULL,			      -- ID of campground the site is at
  site_number integer NOT NULL,                   -- Site numbers are arbitrarily assigned by the campground
  max_occupancy integer NOT NULL DEFAULT 6,       -- Sites are limited to 6 people, however some sites are "doubled" (12 people)
  accessible bit NOT NULL DEFAULT 0,              -- Accessible site, reserved for campers with disabilities
  max_rv_length integer NOT NULL DEFAULT 0,       -- The maximum RV/Trailer length that the campsite can fit. RVs/Trailers not permitted if length is 0
  utilities bit NOT NULL DEFAULT 0,               -- Indicates whether or not the campsite provides access to utility hookup
  CONSTRAINT pk_site_site_number_campground_id PRIMARY KEY (site_id),
  CONSTRAINT fk_site_campground FOREIGN KEY (campground_id) REFERENCES campground(campground_id)
);

CREATE TABLE reservation (
  reservation_id integer identity NOT NULL,
  site_id integer NOT NULL,							-- ID of site the reservation is at
  name varchar(80) NOT NULL,						-- Name for the reservation
  from_date date NOT NULL,							-- Start date of reservation
  to_date date NOT NULL,							-- End date of reservation
  create_date DATETIME DEFAULT GETDATE(),			-- Date the reservation was booked
  CONSTRAINT pk_reservation_reservation_id PRIMARY KEY (reservation_id),
  CONSTRAINT fk_reservation_site FOREIGN KEY (site_id) REFERENCES site(site_id)
);


-- test parks
INSERT INTO park (name, location, establish_date, area, visitors, description)
VALUES ('Park 1', 'Pennsylvania', '1/1/1970', 1024, 512, 'Test description 1')
DECLARE @parkId1 int = (SELECT @@IDENTITY);

INSERT INTO park (name, location, establish_date, area, visitors, description)
VALUES ('Park 2', 'Ohio', '1/1/1970', 2048, 1024, 'Test description 2')


-- test campgrounds
INSERT INTO campground(park_id, name, open_from_mm, open_to_mm, daily_fee)
VALUES (@parkId1, 'Test Campground', '1', '12', 35);
DECLARE @campgroundId int = (SELECT @@IDENTITY);

INSERT INTO campground(park_id, name, open_from_mm, open_to_mm, daily_fee)
VALUES (@parkId1, 'Test Campground', '1', '12', 35);


-- test sites
---- accepts RVs
INSERT INTO site(campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities)
VALUES (@campgroundId, 1, 10, 1, 33, 1);

INSERT INTO site(campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities)
VALUES (@campgroundId, 2, 10, 1, 30, 1);

---- doesn't accept RVs
INSERT INTO site(campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities)
VALUES (@campgroundId, 3, 10, 1, 0, 1);
DECLARE @siteId int = (SELECT @@IDENTITY);


-- test reservations
---- future
INSERT INTO reservation(site_id, name, from_date, to_date, create_date)
VALUES (@siteId, 'Test Testerson', GETDATE() + 1, GETDATE() + 5, GETDATE() - 23);

INSERT INTO reservation(site_id, name, from_date, to_date, create_date)
VALUES (@siteId, 'Bob Robertson', GETDATE() + 11, GETDATE() + 18, GETDATE() - 23);

---- present
INSERT INTO reservation(site_id, name, from_date, to_date, create_date)
VALUES (@siteId, 'Manager Managerson', GETDATE() - 5, GETDATE() + 2, GETDATE() - 23);

---- past
INSERT INTO reservation(site_id, name, from_date, to_date, create_date)
VALUES (@siteId, 'Leonard Leonardson', GETDATE() - 11, GETDATE() - 18, GETDATE() - 23);
DECLARE @reservationId int = (SELECT @@IDENTITY);


-- Return the Ids if needed
SELECT
	@parkId1 as park_id,
	--@campgroundId as campgroundId,
	@siteId as site_id,
	@reservationId as reservation_id;
