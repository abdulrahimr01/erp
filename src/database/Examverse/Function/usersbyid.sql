CREATE OR REPLACE FUNCTION public.fn_usersbyid(
	p_action character varying,
	p_id bigint)
    RETURNS boolean
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
DECLARE
    affected_rows INT;
BEGIN
--delete
IF p_action='Delete' THEN
DELETE FROM users WHERE id=p_id;
GET DIAGNOSTICS affected_rows=ROW_COUNT;
RETURN affected_rows>0;
END IF;

--Update active status
IF p_action='active' THEN
UPDATE users SET isactive=TRUE WHERE id=p_id;
GET DIAGNOSTICS affected_rows=ROW_COUNT;
RETURN affected_rows>0;
END IF;

--Update inactive status
IF p_action='inactive' THEN
UPDATE users SET isactive=FALSE WHERE id=p_id;
GET DIAGNOSTICS affected_rows=ROW_COUNT;
RETURN affected_rows>0;
END IF;
RETURN FALSE;
END
$BODY$