// --------------------------------------------------------------------------------
// Name: CResizableArray
// Abstract: This class will create a resizeable array.
// --------------------------------------------------------------------------------

// --------------------------------------------------------------------------------
// Pre-compiler Directives
// --------------------------------------------------------------------------------
#pragma once
#ifndef CRESIZABLE_ARRAY_H
#define CRESIZABLE_ARRAY_H		// Include this file only once even if referenced multiple times

// --------------------------------------------------------------------------------
// Includes
// --------------------------------------------------------------------------------
#include <stdlib.h>
#include <iostream>
using namespace std;


template <typename GenericDataType>
class CResizableArray
{
	// --------------------------------------------------------------------------------
	// Properties
	// --------------------------------------------------------------------------------
public:			// Never make public properties.  
	// Make protected or private with public get/set methods

protected:

	long m_lngArraySize;
	GenericDataType* m_pagdtValues;

private:

	// --------------------------------------------------------------------------------
	// Methods
	// --------------------------------------------------------------------------------
public:

	// Construtors
	CResizableArray();
	CResizableArray(long lngInitalSize);
	CResizableArray(long lngInitalSize, GenericDataType gdtDefaultValue);
	CResizableArray(const CResizableArray& clsOriginalToCopy);

	// Destructor
	~CResizableArray();

	// Overloaded operators
	void  operator = (const CResizableArray& clsOriginalToCopy);
	GenericDataType  operator [] (const long lngIndex) const;
	GenericDataType& operator [] (long lngIndex);
	void operator += (const CResizableArray& clsOriginalToAppend);

	// Array Size
	void SetSize(long lngNewSize);
	void SetSize(long lngNewSize, GenericDataType gdtDefaultValue);
	long GetSize() const;

	// Set & Get Array Value
	void SetValueAt(GenericDataType gdtValue, long lngIndex);
	GenericDataType GetValueAt(long lngIndex) const;

	// Add Value to Front & End
	void AddValueToFront(GenericDataType gdtValueToAdd);
	void AddValueToEnd(GenericDataType gdtValue);

	// Insert a value at given index
	void InsertValueAt(GenericDataType gdtValue, long lngIndexToInsertAt);

	// Remove value at given index
	void RemoveAt(long lngIndextoRemoveAt);

	// Print
	void Print() const;
	void Print(const char* pstrCaption) const;


protected:
	void Initialize(long lngInitalSize, GenericDataType gdtDefaultValue);
	void CleanUp();
	void DeepCopy(const CResizableArray& clsOriginalToCopy);
private:

};

// Inculde method definitions so we can have separate files for
// class declaration and method definitions like every other class
#include "CResizableArray.cpp"

#endif