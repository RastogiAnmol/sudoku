import React from 'react';
import Grid from './components/Grid';
import { solver, isSolvable, isComplete } from './utils/sudoku';
import { solve, clear, undo } from './actions/grid';

/* Application Container Component */
class App extends React.Component {
    componentDidMount() {
        this.unsubscribe = this.props.store.subscribe(() => {
            this.forceUpdate();
        })
    }
    componentWillUnmount() {
        this.unsubscribe();
    }
    render() {
        const { store } = this.props;
        const { grid, status } = store.getState();
        const { isSolved, isEdited } = status;
        return (
            <div>

                <button
                    className='check'
                    disabled={isSolved}
                    onClick={() => {
                        if (isSolvable(grid)) {
                            if (isComplete(grid)) {
                                return alert('Congratulations, you solved it!!');
                            }
                            alert('This Sudoku is solvable, keep going !!');
                        } else {
                            alert('This Sudoku is NOT solvable');
                        }
                    }}
                >
                    Check
    </button>
                <button
                    className='solve'
                    onClick={() => store.dispatch(solve())}
                >
                    Solve
    </button>
                <Grid grid={grid} status={status} {...this.props} />
                <div className='footnote'>
                    <h2>India is diverse and colorful.</h2>
                </div>
            </div>

        );
    }
}

export default App;
