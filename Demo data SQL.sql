
create database demo
use demo

CREATE TABLE customer (
  id            varchar(16) NOT NULL, 
  full_name     varchar(64) NULL, 
  date_of_birth date NULL, 
  gender        bit NULL, 
  email         varchar(64) NULL, 
  phone         varchar(16) NULL, 
  address       varchar(128) NULL, 
  is_company    bit NULL, 
  buy_rank      int NULL, 
  create_date   datetime NULL, 
  PRIMARY KEY (id));
CREATE TABLE product (
  id            varchar(16) NOT NULL, 
  name          varchar(64) NULL, 
  unit          varchar(16) NULL, 
  unit_price    decimal(10, 2) NULL, 
  unit_in_stock int NULL, 
  PRIMARY KEY (id));
CREATE TABLE order_item (
  id               varchar(16) NOT NULL, 
  quantity         int NULL, 
  discount_percent decimal(3, 0) NULL, 
  order_id         varchar(16) NOT NULL, 
  product_id       varchar(16) NOT NULL, 
  PRIMARY KEY (id));
CREATE TABLE [order] (
  id             varchar(16) NOT NULL, 
  order_date     datetime NULL, 
  ship_address   varchar(128) NULL, 
  ship_date      datetime NULL, 
  customer_id    varchar(16) NOT NULL, 
  employee_id    varchar(16) NULL, 
  lead_status_id varchar(16) NULL, 
  PRIMARY KEY (id));
CREATE TABLE employee (
  id                varchar(16) NOT NULL, 
  full_name         varchar(64) NULL, 
  date_of_birth     date NULL, 
  gender            bit NULL, 
  email             varchar(64) NULL, 
  phone             varchar(16) NULL, 
  address           varchar(64) NULL, 
  account_name      varchar(64) NULL, 
  acccount_password varchar(64) NULL, 
  account_role      varchar(64) NULL, 
  salary            int NULL, 
  hire_date         date NULL, 
  sales_team_id     varchar(16) NULL, 
  PRIMARY KEY (id));
CREATE TABLE sales_team (
  id             varchar(16) NOT NULL, 
  name           varchar(64) NULL, 
  revenue_target int NULL, 
  team_leader_id varchar(16) NOT NULL, 
  pipeline_id    varchar(16) NOT NULL, 
  PRIMARY KEY (id));
CREATE TABLE source (
  id   varchar(16) NOT NULL, 
  name varchar(64) NULL, 
  PRIMARY KEY (id));
CREATE TABLE pipeline (
  id   varchar(16) NOT NULL, 
  name varchar(64) NULL, 
  PRIMARY KEY (id));
CREATE TABLE stage (
  id   varchar(16) NOT NULL, 
  name varchar(64) NULL, 
  PRIMARY KEY (id));
CREATE TABLE lead_stage (
  id                  varchar(16) NOT NULL, 
  start_date          datetime NULL, 
  end_date            datetime NULL, 
  stage_id            varchar(16) NOT NULL, 
  create_employee_id  varchar(16) NOT NULL, 
  lead_oppurtunity_id varchar(16) NOT NULL, 
  PRIMARY KEY (id));
CREATE TABLE lead_oppurtunity (
  id                    varchar(16) NOT NULL, 
  name                  varchar(64) NULL, 
  urgency               int NULL, 
  expected_revenue      int NULL, 
  expected_closing_date datetime NULL, 
  create_date           datetime NULL, 
  source_id             varchar(16) NULL, 
  create_employee_id    varchar(16) NOT NULL, 
  marketing_campaign_id varchar(16) NULL, 
  PRIMARY KEY (id));
CREATE TABLE lead_status (
  id             varchar(16) NOT NULL, 
  status         bit NULL, 
  create_date    datetime NULL, 
  lost_reason_id varchar(16) NULL, 
  PRIMARY KEY (id));
CREATE TABLE lost_reason (
  id   varchar(16) NOT NULL, 
  name varchar(64) NULL, 
  PRIMARY KEY (id));
CREATE TABLE marketing_campaign (
  id         varchar(16) NOT NULL, 
  name       varchar(64) NULL, 
  start_date date NULL, 
  end_date   date NULL, 
  PRIMARY KEY (id));
CREATE TABLE pipeline_stage (
  pipeline_id varchar(16) NOT NULL, 
  stage_id    varchar(16) NOT NULL, 
  stage_order int NULL, 
  PRIMARY KEY (pipeline_id, 
  stage_id));
CREATE TABLE customer_marketing_campaign (
  customer_id           varchar(16) NOT NULL, 
  marketing_campaign_id varchar(16) NOT NULL, 
  sent_date             date NULL, 
  channel               varchar(64) NULL, 
  PRIMARY KEY (customer_id, 
  marketing_campaign_id));
ALTER TABLE employee ADD CONSTRAINT [FK-sales_team-employee2] FOREIGN KEY (sales_team_id) REFERENCES sales_team (id);
ALTER TABLE sales_team ADD CONSTRAINT [FK-employee-sales_team2] FOREIGN KEY (team_leader_id) REFERENCES employee (id);
ALTER TABLE [order] ADD CONSTRAINT [FK-customer-order2] FOREIGN KEY (customer_id) REFERENCES customer (id);
ALTER TABLE order_item ADD CONSTRAINT [FK-order-order_item2] FOREIGN KEY (order_id) REFERENCES [order] (id);
ALTER TABLE order_item ADD CONSTRAINT [FK-product-order_item2] FOREIGN KEY (product_id) REFERENCES product (id);
ALTER TABLE [order] ADD CONSTRAINT [FK-employee-order2] FOREIGN KEY (employee_id) REFERENCES employee (id);
ALTER TABLE lead_oppurtunity ADD CONSTRAINT [FK-source-lead_oppurtunity2] FOREIGN KEY (source_id) REFERENCES source (id);
ALTER TABLE lead_status ADD CONSTRAINT [FK-lead_oppurtunity-lead_status2] FOREIGN KEY (id) REFERENCES lead_oppurtunity (id);
ALTER TABLE lead_oppurtunity ADD CONSTRAINT [FK-employee-lead_oppurtunity2] FOREIGN KEY (create_employee_id) REFERENCES employee (id);
ALTER TABLE lead_stage ADD CONSTRAINT [FK-stage-lead_stage2] FOREIGN KEY (stage_id) REFERENCES stage (id);
ALTER TABLE lead_stage ADD CONSTRAINT [FK-employee-lead_stage2] FOREIGN KEY (create_employee_id) REFERENCES employee (id);
ALTER TABLE lead_status ADD CONSTRAINT [FK-lost_reason-lead_status2] FOREIGN KEY (lost_reason_id) REFERENCES lost_reason (id);
ALTER TABLE sales_team ADD CONSTRAINT [FK-pipeline-sales_team2] FOREIGN KEY (pipeline_id) REFERENCES pipeline (id);
ALTER TABLE lead_stage ADD CONSTRAINT [FK-lead_oppurtunity-lead_stage2] FOREIGN KEY (lead_oppurtunity_id) REFERENCES lead_oppurtunity (id);
ALTER TABLE lead_oppurtunity ADD CONSTRAINT [FK-marketing_campaign-lead_oppurtunity2] FOREIGN KEY (marketing_campaign_id) REFERENCES marketing_campaign (id);
ALTER TABLE pipeline_stage ADD CONSTRAINT [FK-pipeline-pipeline_stage] FOREIGN KEY (pipeline_id) REFERENCES pipeline (id);
ALTER TABLE pipeline_stage ADD CONSTRAINT [FK-stage-pipeline_stage] FOREIGN KEY (stage_id) REFERENCES stage (id);
ALTER TABLE [order] ADD CONSTRAINT [FK-lead_status-order2] FOREIGN KEY (lead_status_id) REFERENCES lead_status (id);
ALTER TABLE customer_marketing_campaign ADD CONSTRAINT [FK-customer-customer_marketing_campaign] FOREIGN KEY (customer_id) REFERENCES customer (id);
ALTER TABLE customer_marketing_campaign ADD CONSTRAINT [FK-marketing_campaign-customer_marketing_campaign] FOREIGN KEY (marketing_campaign_id) REFERENCES marketing_campaign (id);

---


-- Product
INSERT INTO product (id, name, unit, unit_price, unit_in_stock)
VALUES
  ('PRO001', 'But bi', 'Cai', 1.99, 100),
  ('PRO002', 'Giay A4', 'To', 5.99, 500),
  ('PRO003', 'Muc in', 'Lo', 8.49, 50);


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
WHERE id IN ('EMP001', 'EMP002', 'EMP04'); 

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


-- Lead_status
INSERT INTO lead_status (id, status, create_date, lost_reason_id)
VALUES
  ('LST001', 1, '2023-11-01 14:30:00', NULL), -- Thành công
  ('LST002', 1, '2023-11-05 09:45:00', NULL), -- Thành công
  ('LST003', 0, '2023-11-10 16:20:00', 'LOS001'); -- Thất bại với lý do


-- Order 
INSERT INTO [order] (id, order_date, ship_address, ship_date, customer_id, employee_id, lead_status_id)
VALUES
  ('ORD001', '2023-11-20 13:45:00', '456 Oak St, Town', '2023-11-25 15:30:00', 'CUS001', 'EMP001', 'LST005'),
  ('ORD002', '2023-11-25 10:30:00', '789 Elm St, City', '2023-11-30 12:40:00', 'CUS002', 'EMP002', 'LST006'),
  ('ORD003', '2023-12-01 14:30:00', '321 Main St, Village', '2023-12-05 10:00:00', 'CUS003', 'EMP003', 'LST005'),
  ('ORD004', '2023-12-05 09:45:00', '987 Pine St, County', '2023-12-10 11:30:00', 'CUS004', 'EMP004', 'LST001'),
  ('ORD005', '2023-12-10 16:20:00', '456 Oak St, Town', '2023-12-15 14:15:00', 'CUS001', 'EMP001', 'LST002'),
  ('ORD006', '2023-12-15 11:10:00', '789 Elm St, City', '2023-12-20 09:20:00', 'CUS002', 'EMP002', 'LST003');


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
  ('LOP001', 'Opportunity 1 for CUS001', 3, 5000, '2023-11-10 14:30:00', '2023-11-01 14:30:00', 'SOU001', 'EMP001', 'MAR001'), -- Thành công
  ('LOP002', 'Opportunity 2 for CUS001', 2, 8000, '2023-11-15 09:45:00', '2023-11-05 09:45:00', 'SOU002', 'EMP001', 'MAR001'); -- Thành công

-- Lead_opportunity for C002
INSERT INTO lead_oppurtunity (id, name, urgency, expected_revenue, expected_closing_date, create_date, source_id, create_employee_id, marketing_campaign_id)
VALUES
  ('LOP003', 'Opportunity for CUS002', 1, 6000, '2023-11-10 16:20:00', '2023-11-10 16:20:00','SOU001', 'EMP002', NULL); -- Thất bại




