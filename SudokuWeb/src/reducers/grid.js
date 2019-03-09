import cloneDeep from 'lodash/cloneDeep';
import { default as extend } from 'lodash/assignIn';
import { solver } from '../utils/sudoku';

const initialState = [
    [3, 0, 1, 7, 5, 4, 6, 0, 8],
    [6, 0, 8, 2, 0, 3, 1, 5, 7],
    [5, 0, 9, 8, 0, 0, 2, 0, 4],
    [7, 0, 2, 0, 4, 5, 0, 6, 1],
    [9, 0, 5, 1, 8, 0, 4, 2, 3],
    [1, 0, 4, 0, 6, 2, 8, 7, 5],
    [8, 0, 3, 0, 2, 0, 7, 4, 6],
    [2, 0, 6, 4, 0, 8, 0, 1, 9],
    [4, 0, 7, 6, 0, 9, 5, 8, 2]
];

window.gridHistory = window.gridHistory || [];

export function grid(state = cloneDeep(initialState), action) {
	switch (action.type) {
		case 'INPUT_VALUE':
			let {row, col, val} = action;
			let changedRow = [
				...state[row].slice(0, col),
				val,
				...state[row].slice(col + 1)
			]; // Omit using splice since it mutates the state
			gridHistory.push(state);		
			return [
				...state.slice(0, row),
				changedRow,
				...state.slice(row + 1)
			];
		case 'SOLVE':
			let originalClone = cloneDeep(initialState); // originalClone will be mutated by solver()
			solver(originalClone);
			window.gridHistory = [];
			return originalClone;
		case 'CLEAR':
			window.gridHistory = [];
			return cloneDeep(initialState);
		case 'UNDO':
			let lastState = window.gridHistory.splice(gridHistory.length - 1, 1);
			return lastState[0]; 
		default:
			return state;
	}
}
