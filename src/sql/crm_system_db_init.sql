
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
