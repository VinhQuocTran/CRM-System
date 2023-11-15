
-- Product
INSERT INTO product (id, name, unit, unit_price, unit_in_stock)
VALUES
  ('PRO001', 'But bi', 'Cai', 1.99, 100),
  ('PRO002', 'Giay A4', 'To', 5.99, 500),
  ('PRO003', 'Muc in', 'Lo', 8.49, 50);


-- Customer
INSERT INTO customer (id, full_name, date_of_birth, gender, email, phone, address, is_company, buy_rank, create_date)
VALUES
  ('CUS001', 'Sarah Adams', '1987-09-12', 0, 'sarah.adams@example.com', '555-789-1234', '456 Oak St, Town', 0, 4, '2022-11-25 13:40:00'),
  ('CUS002', 'Michael Brown', '1993-03-30', 1, 'michael.brown@example.com', '888-999-7777', '789 Elm St, City', 0, 5, '2022-08-15 16:10:00'),
  ('CUS003', 'Linda Wilson', '1980-07-22', 0, 'linda.wilson@example.com', '777-222-3333', '321 Main St, Village', 1, 2, '2023-02-18 09:55:00'),
  ('CUS004', 'Daniel Miller', '1991-01-05', 1, 'daniel.miller@example.com', '123-987-6543', '987 Pine St, County', 0, 3, '2022-10-10 10:30:00');


-- Pipeline
INSERT INTO pipeline (id, name)
VALUES
  ('PIP001', 'Sales Pipeline'),
  ('PIP002', 'Up-Sales Pipeline');


-- Employee
INSERT INTO employee (id, full_name, date_of_birth, gender, email, phone, address, account_name, acccount_password, account_role, salary, hire_date, sales_team_id)
VALUES
  ('EMP001', 'John Doe', '1990-05-15', 1, 'john.doe@example.com', '123-456-7890', '123 Main St, City', 'johndoe', 'password123', 'Sales Associate', 50000, '2022-03-10', NULL),
  ('EMP002', 'Alex Smith', '1985-08-20', 0, 'alex.smith@example.com', '987-654-3210', '456 Elm St, Town', 'alexsmith', 'secret789', 'Manager', 65000, '2021-12-15', NULL),
  ('EMP003', 'Bob Johnson', '1995-02-28', 1, 'bob.johnson@example.com', '555-123-7890', '789 Oak St, Village', 'bobjohnson', 'bobspass', 'Sales Associate', 48000, '2022-05-20', NULL),
  ('EMP004', 'Alice Lee', '1998-04-10', 0, 'alice.lee@example.com', '777-333-2222', '321 Pine St, County', 'alicelee', 'p@ssw0rd', 'Intern', 30000, '2023-01-05', NULL),
  ('EMP005', 'Ben Scalet', '1998-04-10', 1, 'ben.scalet@example.com', '135-234-7890', '115 Pine St, County', 'benscalet', '123ben', 'Intern', 40000, '2023-02-13', NULL);


-- Sales_teams
INSERT INTO sales_team (id, name, revenue_target, team_leader_id, pipeline_id)
VALUES
  ('SAL001', 'Sales Team', 1000000, 'EMP001', 'PIP001'),
  ('SAL002', 'Post-Sales Team', 800000, 'EMP003', 'PIP002');


-- Update sales_team_id for employees
UPDATE employee
SET sales_team_id = 'SAL001'
WHERE id IN ('EMP001', 'EMP002', 'EMP004'); 

UPDATE employee
SET sales_team_id = 'SAL002'
WHERE id IN ('EMP003', 'EMP005'); 

-- Stage
INSERT INTO stage (id, name)
VALUES
  ('STA001', 'Lead qualification'),
  ('STA002', 'Demo or meeting (telephone, email, real-life meeting..)'),
  ('STA003', 'Create proposal for pre-sales'),
  ('STA004', 'Create proposal for up-sales'),
  ('STA005', 'Negotiation and manage expectation'),
  ('STA006', 'Opportunity won');


-- Pipeline_stage
-- Sales_pipeline
INSERT INTO pipeline_stage (pipeline_id, stage_id, stage_order)
VALUES
  ('PIP001', 'STA001', 1), -- Lead qualification
  ('PIP001', 'STA002', 2), -- Demo or meeting
  ('PIP001', 'STA003', 3), -- Create proposal for pre-sales
  ('PIP001', 'STA005', 4), -- Negotiation and manage expectation
  ('PIP001', 'STA006', 5); -- Opportunity won


-- Up-sales pipeline
INSERT INTO pipeline_stage (pipeline_id, stage_id, stage_order)
VALUES
  ('PIP002', 'STA004', 1), -- Create proposal for up-sales
  ('PIP002', 'STA002', 2), -- Demo or meeting
  ('PIP002', 'STA005', 3), -- Negotiation and manage expectation
  ('PIP002', 'STA006', 4); -- Opportunity won


-- Lost_reason
INSERT INTO lost_reason (id, name)
VALUES
  ('LOS001', 'No Budget'),
  ('LOS002', 'Not Interested'),
  ('LOS003', 'Competitor Chose');


-- Marketing_campaign "Black Friday"
INSERT INTO marketing_campaign (id, name, start_date, end_date)
VALUES
  ('MAR001', 'Black Friday', '2023-11-24', '2023-12-01');


-- Customer_marketing_campaign
INSERT INTO customer_marketing_campaign (customer_id, marketing_campaign_id, sent_date, channel)
VALUES
  ('CUS001', 'MAR001', '2023-11-02', 'Email'),
  ('CUS002', 'MAR001', '2023-11-03', 'SMS');


-- Source
INSERT INTO source (id, name)
VALUES
  ('SOU001', 'Website'),
  ('SOU002', 'Referral');


-- Lead_opportunities for C001
INSERT INTO lead_oppurtunity (id, name, urgency, expected_revenue, expected_closing_date, create_date, source_id, create_employee_id, marketing_campaign_id)
VALUES
  ('LOP001', 'Opportunity for CUS001', 3, 5000, '2023-11-10 14:30:00', '2023-11-01 14:30:00', 'SOU001', 'EMP001', 'MAR001'), -- Thành công
  ('LOP002', 'Opportunity for CUS002', 2, 8000, '2023-11-15 09:45:00', '2023-11-05 09:45:00', 'SOU002', 'EMP002', 'MAR001'); -- Thành công

-- Lead_opportunity for C002
INSERT INTO lead_oppurtunity (id, name, urgency, expected_revenue, expected_closing_date, create_date, source_id, create_employee_id, marketing_campaign_id)
VALUES
  ('LOP003', 'Opportunity for CUS003', 1, 6000, '2023-11-10 16:20:00', '2023-11-10 16:20:00','SOU001', 'EMP003', NULL); -- Thất bại


-- Lead_status
INSERT INTO lead_status (id, status, create_date, lost_reason_id)
VALUES
  ('LOP001', 1, '2023-11-01 14:30:00', NULL), -- Thành công
  ('LOP002', 1, '2023-11-05 09:45:00', NULL), -- Thành công
  ('LOP003', 0, '2023-11-10 16:20:00', 'LOS001'); -- Thất bại với lý do


  -- Order 
INSERT INTO [order] (id, order_date, ship_address, ship_date, customer_id, employee_id, lead_status_id)
VALUES
  ('ORD001', '2023-11-20 13:45:00', '456 Oak St, Town', '2023-11-25 15:30:00', 'CUS001', 'EMP001', 'LOP001'),
  ('ORD002', '2023-11-25 10:30:00', '789 Elm St, City', '2023-11-30 12:40:00', 'CUS002', 'EMP002', 'LOP002'),
  ('ORD003', '2023-12-01 14:30:00', '321 Main St, Village', '2023-12-05 10:00:00', 'CUS003', 'EMP003', 'LOP003'),
  ('ORD004', '2023-12-05 09:45:00', '987 Pine St, County', '2023-12-10 11:30:00', 'CUS004', 'EMP004', 'LOP001'),
  ('ORD005', '2023-12-10 16:20:00', '456 Oak St, Town', '2023-12-15 14:15:00', 'CUS001', 'EMP005', 'LOP002'),
  ('ORD006', '2023-12-15 11:10:00', '789 Elm St, City', '2023-12-20 09:20:00', 'CUS002', 'EMP001', 'LOP003');