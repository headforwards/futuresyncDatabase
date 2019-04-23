import React from 'react'
import Enzyme from 'enzyme'
import DatabaseReset from './DatabaseReset'

describe('Database Reset', () => {
    it('it renders without crashing', async () => {
        var databaseReset =  await Enzyme.shallow(<DatabaseReset />)
    })
})