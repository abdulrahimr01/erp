-- Table: public.books

-- DROP TABLE IF EXISTS public.books;

CREATE TABLE IF NOT EXISTS public.books
(
    id bigint NOT NULL DEFAULT nextval('books_id_seq'::regclass),
    title character varying(100) COLLATE pg_catalog."default" NOT NULL,
    examname character varying(100) COLLATE pg_catalog."default" NOT NULL,
    author character varying(100) COLLATE pg_catalog."default",
    price numeric(10,2) NOT NULL,
    originalprice numeric(10,2) NOT NULL,
    description character varying(200) COLLATE pg_catalog."default",
    details character varying(1000) COLLATE pg_catalog."default" NOT NULL,
    stocks integer,
    isactive boolean NOT NULL,
    actionby character varying(50) COLLATE pg_catalog."default" NOT NULL,
    actiondate timestamp without time zone NOT NULL,
    frontimage bytea,
    backimage bytea,
    course character varying(100) COLLATE pg_catalog."default",
    CONSTRAINT books_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.books
    OWNER to postgres;