/*
 program  ----> block
block       ----> { decls stmts } 
decls       ----> decls decl | e 
decl         ----> type id ; 
type         ----> type [ num ] | basic 
stmts       ----> stmts stmt  | e 
stmt         ----» loc = bool ; 
                       | if ( bool) stmt 
                       | if ( bool) stmt else stmt 
                       | while ( bool) stmt 
                       | do stmt while ( bool) ; 
                       | break ; 
                       | continue;
                       | return;
                       | block 
                       | ;
loc           ----> loc [ bool ] 
                       | id
bool         ----> bool || join 
                       | join
join          ----> join && equality 
                      | equality
equality   ----> equality == rel 
                      | equality ! = rel 
                      | rel
rel           ----> expr   < expr 
                      | expr <= expr
                      | expr >= expr
                      | expr > expr 
                      | expr
expr        ----> expr + term 
                      | expr - term 
                      | term
term        ----> term  *   unary 
                      | term /   unary 
                      | term % unary 
                      | unary
unary      ----> ! unary 
                      | - unary
                      | factor
factor      ----> ( bool ) 
                      | loc 
                      | num
                      | real 
                      | true 
                      | false
                       
                      
                      
block_statements --->
		block_statement
	|	block_statements block_statement
	;
block_statement --->
		local_variable_declaration_statement
	|	statement
	|	class_declaration
	|	interface_declaration
	;
statement --->	statement_without_trailing_substatement
	|	labeled_statement
	|	if_then_statement
	|	if_then_else_statement
	|	while_statement
	|	for_statement
	;
statement_no_short_if --->
		statement_without_trailing_substatement
	|	labeled_statement_no_short_if
	|	if_then_else_statement_no_short_if
	|	while_statement_no_short_if
	|	for_statement_no_short_if
	;
statement_without_trailing_substatement --->
		block
	|	empty_statement
	|	expression_statement
	|	switch_statement
	|	do_statement
	|	break_statement
	|	continue_statement
	|	return_statement
	|	synchronized_statement
	|	throw_statement
	|	try_statement

switch_statement --->
		SWITCH ( expression ) switch_block
	;
switch_block --->
		{ switch_block_statement_groups switch_labels }
	|	{ switch_block_statement_groups }
	|	{ switch_labels }
	|	{ }
	;
switch_block_statement_groups --->
		switch_block_statement_group
	|	switch_block_statement_groups switch_block_statement_group
	;
switch_block_statement_group --->
		switch_labels block_statements
	;
switch_labels --->
		switch_label
	|	switch_labels switch_label
	;
switch_label --->
		CASE constant_expression :
	|	DEFAULT :
	;

while_statement --->
		WHILE ( expression ) statement
	;
while_statement_no_short_if --->
		WHILE ( expression ) statement_no_short_if
	;
do_statement --->
		DO statement WHILE ( expression ) ;
	;
for_statement --->
		FOR ( for_init_opt ; expression_opt ;
			for_update_opt ) statement
	;
for_statement_no_short_if --->
		FOR ( for_init_opt ; expression_opt ;
			for_update_opt ) statement_no_short_if
	;
for_init_opt --->
	|	for_init
	;
for_init --->	statement_expression_list
	|	local_variable_declaration
	;
for_update_opt --->
	|	for_update
	;
for_update --->	statement_expression_list
	;
statement_expression_list --->
		statement_expression
	|	statement_expression_list , statement_expression
	;

identifier_opt ---> 
	|	IDENTIFIER
	;

break_statement --->
		BREAK identifier_opt ;
	;

continue_statement --->
		CONTINUE identifier_opt ;
	;
return_statement --->
		RETURN expression_opt ;
	;
throw_statement --->
		THROW expression ;
	;
synchronized_statement --->
		SYNCHRONIZED ( expression ) block
	;
try_statement --->
		TRY block catches
	|	TRY block catches_opt finally
	;
catches_opt --->
	|	catches
	;
catches --->	catch_clause
	|	catches catch_clause
	;
catch_clause --->
		CATCH ( formal_parameter ) block
	;
finally --->	FINALLY block
	;
*/