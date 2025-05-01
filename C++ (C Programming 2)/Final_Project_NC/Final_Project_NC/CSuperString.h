// --------------------------------------------------------------------------------
// Name: CSuperString
// Abstract: This class creates a toolkit for string easy string manipulation
// --------------------------------------------------------------------------------

// --------------------------------------------------------------------------------
// Pre-compiler Directives
// --------------------------------------------------------------------------------
#pragma once		// Include this file only once even if referenced multiple times
// --------------------------------------------------------------------------------
// Includes
// --------------------------------------------------------------------------------
#include <stdlib.h>
#include <iostream>
using namespace std;

class CSuperString
{
	// --------------------------------------------------------------------------------
	// Properties
	// --------------------------------------------------------------------------------
public:			// Never make public properties.  
				// Make protected or private with public get/set methods

protected:

	char* m_pstrSuperString;

private:

	// --------------------------------------------------------------------------------
	// Methods
	// --------------------------------------------------------------------------------
public:

	// Constructors
	CSuperString();
	CSuperString(const char* pstrStringToCopy);
	CSuperString(const bool blnBooleanToCopy);
	CSuperString(const char chrLetterToCopy);
	CSuperString(const short shtShortToCopy);
	CSuperString(const int intIntegerToCopy);
	CSuperString(const long lngLongToCopy);
	CSuperString(const float sngFloatToCopy);
	CSuperString(const double dblDoubleToCopy);
	CSuperString(const CSuperString& ssStringToCopy);

	// Destructor
	virtual ~CSuperString();

	int Length() const;

	// Assignment Operators
	void operator = (const char* pstrSource);
	void operator = (const char chrLetterToCopy);
	void operator = (const CSuperString& ssStringToCopy);

	// Concatenate operators
	void operator += (const char* pstrStringToAppend);
	void operator += (const char chrCharacterToAppend);
	void operator += (const CSuperString& ssStringToAppend);
	friend CSuperString operator + (const CSuperString& ssLeft,
		const CSuperString& ssRight);
	friend CSuperString operator + (const char* pstrLeftSide,
		const CSuperString& ssRightString);
	friend CSuperString operator + (const CSuperString& ssLeftString,
		const char* pstrRightSide);


	// Comparison operators
	bool operator == (const char* pstrStringToCompare) const;
	bool operator == (const char chrCharacterToCompare) const;
	bool operator == (const CSuperString& ssStringToCompare) const;

	// Not equal to operators
	bool operator != (const char* pstrStringToCompare) const;
	bool operator != (const char chrCharacterToCompare) const;
	bool operator != (const CSuperString& ssStringToCompare) const;
	 
	// Greater than operators
	bool operator > (const char* pstrStringToCompare) const;
	bool operator > (const char pstrStringToComapre) const;
	bool operator > (const CSuperString& ssStringToCompare) const;

	// Less than operators
	bool operator < (const char* pstrStringToComapre) const;
	bool operator < (const char pstrStringToComapre) const;
	bool operator < (const CSuperString& ssStringToCompare) const;

	// Greater than equal to operators
	bool operator >= (const char* pstrStringToComapre) const;
	bool operator >= (const char chrCharacterToCompare) const;
	bool operator >= (const CSuperString& ssStringToCompare) const;

	// Less than equal to operators
	bool operator <= (const char* pstrStringToComapre) const;
	bool operator <= (const char chrCharacterToCompare) const;
	bool operator <= (const CSuperString& ssStringToCompare) const;

	// Subscript operator
	char& operator [ ] (int intIndex);
	const char& operator [ ] (int intIndex) const;

	// Istream and Ostream operators
	friend ostream& operator << (ostream& osOut, const CSuperString& ssOutput);
	friend istream& operator >> (istream& isIn, CSuperString& ssInput);

	// StringUtilityFunctions
	int FindFirstIndexOf(const char chrLetterToFind) const;
	int FindFirstIndexOf(const char chrLetterToFind, int intStartIndex) const;
	int FindLastIndexOf(const char chrLetterToFind) const;

	int FindFirstIndexOf(const char* pstrSubStringToFind) const;
	int FindFirstIndexOf(const char* pstrSubStringToFind, int intStartIndex) const;
	int FindLastIndexOf(const char* pstrSubStringToFind) const;

	const char* ToUpperCase() const;
	const char* ToLowerCase() const;
	const char* TrimLeft() const;
	const char* TrimRight() const;
	const char* Trim() const;
	bool IsWhiteSpace(char chrLetterToCheck) const;
	const char* Reverse() const;

	const char* Left(int intCharactersToCopy) const;
	const char* Right(int intCharactersToCopy) const;

	const char* Substring(int intStart, int intSubStringLength) const;

	const char* Replace(char chrLetterToFind, char chrReplace);
	const char* Replace(const char* pstrFind, const char* pstrReplace);

	const char* Insert(const char chrLetterToInsert, int intIndex);
	const char* Insert(const char* pstrSubString, int intIndex);

	// To <data Type> functions
	const char* ToString() const;
	bool ToBoolean() const;
	short ToShort() const;
	int ToInteger() const;
	long ToLong() const;
	float ToFloat() const;
	double ToDouble() const;

	void Print(const char* pstrCaption) const;

protected:
	void Initialize();
	void DeepCopy(const char* pstrSource);
	void CleanUp();
		void DeleteString(char* &pstrSource);

	char* CloneString(const char* pstrSource) const;
	char* GetBuffer(int intSourceSize) const;
	char* GetBuffer(const char* pstrSource) const;


private:

};
