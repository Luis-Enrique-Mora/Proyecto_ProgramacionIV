CREATE TABLE public.invoices (
    invoice_id integer NOT NULL,
    vendor_fk integer NOT NULL,
    date date NOT NULL,
    invoice_number varchar(20) NOT NULL,
    description varchar(255),
    amount numeric(10,2) NOT NULL,
    final_payment numeric(10,2) NOT NULL,
    invoice_category_fk integer NOT NULL,
    payment_category_fk integer NOT NULL,
    status_fk integer NOT NULL,
    PRIMARY KEY (invoice_id)
);

CREATE INDEX ON public.invoices
    (vendor_fk);
CREATE INDEX ON public.invoices
    (invoice_category_fk);
CREATE INDEX ON public.invoices
    (payment_category_fk);
CREATE INDEX ON public.invoices
    (status_fk);


COMMENT ON COLUMN public.invoices.status_fk
    IS 'El estado puede ser pendiente o pagado
';

CREATE TABLE public.vendors (
    vendor_id integer NOT NULL,
    vendor_name varchar(25) NOT NULL,
    person_fk integer NOT NULL,
    company_name varchar(45) NOT NULL,
    phone varchar(50),
    email varchar(100),
    PRIMARY KEY (vendor_id)
);

CREATE INDEX ON public.vendors
    (person_fk);


CREATE TABLE public.phones (
    phone_id integer NOT NULL,
    phone_number varchar(50) NOT NULL,
    person_fk integer NOT NULL,
    PRIMARY KEY (phone_id)
);

CREATE INDEX ON public.phones
    (person_fk);


CREATE TABLE public.persons (
    id_person integer NOT NULL,
    name varchar(25) NOT NULL,
    last_name varchar(25) NOT NULL,
    phone_fk integer NOT NULL,
    email varchar(100) NOT NULL,
    phone_fk  NOT NULL,
    PRIMARY KEY (id_person)
);

ALTER TABLE public.persons
    ADD UNIQUE (email);

CREATE INDEX ON public.persons
    (phone_fk);


CREATE TABLE public.user (
    user_id integer NOT NULL,
    person_fk integer NOT NULL,
    photo bytea NOT NULL,
    password bytea NOT NULL,
    role varchar(25) NOT NULL,
    PRIMARY KEY (user_id)
);

CREATE INDEX ON public.user
    (person_fk);


CREATE TABLE public.user_employee (
    employee_id integer NOT NULL,
    user_fk integer NOT NULL,
    last_name2 varchar(12) NOT NULL,
    cedula varchar(12) NOT NULL,
    salary_per_hour numeric(8,2) NOT NULL,
    PRIMARY KEY (employee_id)
);

CREATE INDEX ON public.user_employee
    (user_fk);


CREATE TABLE public.user_customer (
    customer_id integer NOT NULL,
    column1  NOT NULL,
    PRIMARY KEY (customer_id)
);


CREATE TABLE public.products (
    product_id integer NOT NULL,
    image bytea NOT NULL,
    name varchar(50) NOT NULL,
    description varchar(100) NOT NULL,
    price numeric(8,2) NOT NULL,
    PRIMARY KEY (product_id)
);


CREATE TABLE public.orders (
    order_id integer NOT NULL,
    PRIMARY KEY (order_id)
);


CREATE TABLE public.payment_category (
    payment_id integer NOT NULL,
    payment_name varchar(25) NOT NULL,
    description varchar(255) NOT NULL,
    PRIMARY KEY (payment_id)
);


COMMENT ON COLUMN public.payment_category.payment_name
    IS 'El pago puede ser 
-Transferencia
-Efectivo
-Caja registradora
-Caja fuerte';

CREATE TABLE public.invoice_status (
    status_id integer NOT NULL,
    name varchar(25) NOT NULL,
    description varchar(255),
    PRIMARY KEY (status_id)
);


CREATE TABLE public.invoice_category (
    invoice_category_id integer NOT NULL,
    invoice_category_name varchar(25) NOT NULL,
    PRIMARY KEY (invoice_category_id)
);


ALTER TABLE public.invoices ADD CONSTRAINT FK_invoices__vendor_fk FOREIGN KEY (vendor_fk) REFERENCES public.vendors(vendor_id);
ALTER TABLE public.invoices ADD CONSTRAINT FK_invoices__invoice_category_fk FOREIGN KEY (invoice_category_fk) REFERENCES public.invoice_category(invoice_category_id);
ALTER TABLE public.invoices ADD CONSTRAINT FK_invoices__payment_category_fk FOREIGN KEY (payment_category_fk) REFERENCES public.payment_category(payment_id);
ALTER TABLE public.invoices ADD CONSTRAINT FK_invoices__status_fk FOREIGN KEY (status_fk) REFERENCES public.invoice_status(status_id);
ALTER TABLE public.vendors ADD CONSTRAINT FK_vendors__person_fk FOREIGN KEY (person_fk) REFERENCES public.persons(id_person);
ALTER TABLE public.phones ADD CONSTRAINT FK_phones__person_fk FOREIGN KEY (person_fk) REFERENCES public.persons(phone_fk);
ALTER TABLE public.user ADD CONSTRAINT FK_user__person_fk FOREIGN KEY (person_fk) REFERENCES public.persons(id_person);
ALTER TABLE public.user_employee ADD CONSTRAINT FK_user_employee__user_fk FOREIGN KEY (user_fk) REFERENCES public.user(user_id);